using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WrbDeTai.Data;
using WrbDeTai.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WrbDeTai.Controllers
{
    public class TopicController : Controller
    {
        private readonly ProjectManagerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TopicController(ProjectManagerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        public async Task<IActionResult> Select()
        {
            string studentId = HttpContext.Session.GetString("StudentId");
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
            {
                return NotFound();
            }

            // Kiểm tra sinh viên đã đăng ký đề tài nào chưa
            var existingTopic = await _context.Topics
                .Where(t => t.StudentId == studentId)
                .Select(t => new
                {
                    t.Id,
                    t.TopicName,
                    t.TeacherId
                })
                .FirstOrDefaultAsync();

            // Lấy tên giáo viên hướng dẫn (nếu có)
            string selectedTeacherName = "";
            if (existingTopic?.TeacherId != null)
            {
                selectedTeacherName = await _context.Teachers
                    .Where(t => t.Id == existingTopic.TeacherId)
                    .Select(t => t.Name)
                    .FirstOrDefaultAsync() ?? "Chưa chọn";
            }

            // Chỉ hiển thị các đề tài chưa có sinh viên đăng ký và có trạng thái = 2
            var availableTopics = await _context.Topics
                .Where(t => t.Status == 2 && t.StudentId == null)
                .Select(t => new Models.Topic
                {
                    Id = t.Id,
                    TopicName = t.TopicName,
                    Description = t.Description,
                    TeacherId = t.TeacherId ?? 0,
                    StudentId = t.StudentId,
                    Status = t.Status ?? 2,
                    CreatedDate = t.CreatedDate ?? DateTime.Now,
                    ModifiedDate = t.ModifiedDate
                })
                .ToListAsync();

            var teachers = await _context.Teachers
                .Select(t => new TeacherViewModel { TeacherId = t.Id, Name = t.Name })
                .ToListAsync();

            var viewModel = new TopicSelectionViewModel
            {
                StudentId = studentId,
                StudentName = student.Name,
                SelectedTopicId = existingTopic?.Id,
                SelectedTopicName = existingTopic?.TopicName ?? "Chưa chọn",
                SelectedTeacherId = existingTopic?.TeacherId,
                SelectedTeacherName = selectedTeacherName,
                AvailableTopics = availableTopics,
                AvailableTeachers = teachers
            };

            return View(viewModel);
        }


        // POST: /Topic/Select
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Select(TopicSelectionViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    // Kiểm tra nếu SelectedTopicId bị thiếu
            //    if (model.SelectedTopicId == null || model.SelectedTopicId == 0)
            //    {
            //        ModelState.AddModelError("SelectedTopicId", "Vui lòng chọn một đề tài.");
            //    }

            //    // Load lại danh sách dữ liệu
            //    model.AvailableTopics = await _context.Topics
            //        .Where(t => t.Status == 2 && t.StudentId == null)
            //        .Select(t => new Models.Topic
            //        {
            //            Id = t.Id,
            //            TopicName = t.TopicName,
            //            Description = t.Description,
            //            TeacherId = t.TeacherId ?? 0,
            //            StudentId = t.StudentId,
            //            Status = t.Status ?? 2,
            //            CreatedDate = t.CreatedDate ?? DateTime.Now,
            //            ModifiedDate = t.ModifiedDate
            //        })
            //        .ToListAsync();

            //    model.AvailableTeachers = await _context.Teachers
            //        .Select(t => new TeacherViewModel { TeacherId = t.Id, Name = t.Name })
            //        .ToListAsync();

            //    return View(model);
            //}

            // Lấy đề tài mà sinh viên đã chọn trước đó (nếu có)
            var existingTopic = await _context.Topics.FirstOrDefaultAsync(t => t.StudentId == model.StudentId);
            if (existingTopic != null)
            {
                // Hủy đăng ký đề tài cũ, đặt lại trạng thái ban đầu
                existingTopic.StudentId = null;
                existingTopic.TeacherId = null;
                existingTopic.Status = 2;
                existingTopic.ModifiedDate = DateTime.Now;
            }

            // Lấy đề tài mới mà sinh viên muốn đăng ký
            var selectedTopic = await _context.Topics.FirstOrDefaultAsync(t => t.Id == model.SelectedTopicId && t.StudentId == null);
            if (selectedTopic != null)
            {
                // Gán StudentId vào đề tài mới
                selectedTopic.StudentId = model.StudentId;

                if (model.SelectedTeacherId.HasValue && model.SelectedTeacherId.Value > 0)
                {
                    // Nếu chọn giáo viên -> Đề tài có người hướng dẫn (status = 0)
                    selectedTopic.TeacherId = model.SelectedTeacherId.Value;
                    selectedTopic.Status = 0;
                    TempData["SuccessMessage"] = "Đăng ký đề tài thành công với giáo viên hướng dẫn!";
                }
                else
                {
                    // Nếu chưa chọn giáo viên -> Đề tài đang chờ giáo viên (status = 1)
                    selectedTopic.TeacherId = null;
                    selectedTopic.Status = 1;
                    TempData["SuccessMessage"] = "Đăng ký đề tài thành công! Bạn chưa chọn giáo viên hướng dẫn.";
                }

                selectedTopic.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();

                return RedirectToAction("Select");
            }

            ModelState.AddModelError("", "Không tìm thấy đề tài hoặc đề tài đã được đăng ký bởi sinh viên khác.");

            // Load lại danh sách đề tài và giáo viên
            model.AvailableTopics = await _context.Topics
                .Where(t => t.Status == 2 && t.StudentId == null)
                .Select(t => new Models.Topic
                {
                    Id = t.Id,
                    TopicName = t.TopicName,
                    Description = t.Description,
                    TeacherId = t.TeacherId ?? 0,
                    StudentId = t.StudentId,
                    Status = t.Status ?? 2,
                    CreatedDate = t.CreatedDate ?? DateTime.Now,
                    ModifiedDate = t.ModifiedDate
                })
                .ToListAsync();

            model.AvailableTeachers = await _context.Teachers
                .Select(t => new TeacherViewModel { TeacherId = t.Id, Name = t.Name })
                .ToListAsync();

            return View(model);
        }
    }
}
