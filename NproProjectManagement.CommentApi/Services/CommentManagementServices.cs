using NproProjectManagement.Interfaces;
using Microsoft.EntityFrameworkCore;
using NproProjectManagement.Model;
using NproProjectManagement.CommandDTO;
using NproProjectManagement.CommentApi.DBContext;

namespace NproProjectManagement.Services
{
    public class CommentManagementServices : ICommentManagementServices
    {
        private readonly DBConnection _unitOfWork;
        public CommentManagementServices(DBConnection unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Commanddto>> GetCommentDetails()
        {
            try
            {
                List<Commanddto> result = await _unitOfWork.Comment
             .OrderByDescending(Comment => Comment.Deadline)
             .Select(Comment => new Commanddto
             {
                 CommentID = Comment.CommentID,
                 Content = Comment.Content,
                 //  Deadline = Comment.Deadline,
                 Timestamp = Comment.Timestamp,
                 Status = Comment.Status,
                 UserID = Comment.UserID

             })
             .ToListAsync();

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Commanddto>> GetCommentDetailById(int commentId)
        {
            try
            {
                List<Commanddto> result = await _unitOfWork.Comment
                    .Where(Comment => Comment.CommentID == commentId)
                    .OrderByDescending(Comment => Comment.CommentID)
                    .Select(Comment => new Commanddto
                    {
                        CommentID = Comment.CommentID,
                        Content = Comment.Content,
                        Deadline = Comment.Deadline,
                        Timestamp = Comment.Timestamp,
                        Status = Comment.Status,
                        UserID = Comment.UserID
                    })
                    .ToListAsync();

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Commanddto>> GetCommentDetailByTaskId(int taskId)
        {
            try
            {
                List<Commanddto> result = await _unitOfWork.Comment
                    .Where(Comment => Comment.TaskID == taskId)
                    .OrderByDescending(Comment => Comment.CommentID)
                    .Select(Comment => new Commanddto
                    {
                        CommentID = Comment.CommentID,
                        Content = Comment.Content,
                        //  Deadline = Comment.Deadline,
                        Timestamp = Comment.Timestamp,
                        Status = Comment.Status,
                        UserID = Comment.UserID
                    })
                    .ToListAsync();

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Commanddto?> SaveCommentDetail(Commanddto commanddto)
        {
            try
            {
                // Check if taskManagementDTO is null
                if (commanddto == null)
                {
                    // Set default error response
                    return new Commanddto { Status = "Comment data is null." };
                }

                // Check if CommentID is zero (indicating a new task)
                if (commanddto.CommentID == 0)
                {
                    // Save new task
                    var newTask = new Comment
                    {
                        Content = commanddto.Content,
                        UserID = commanddto.UserID,
                        TaskID = commanddto.TaskID,
                        Status = commanddto.Status,
                        Timestamp = commanddto.Timestamp
                    };

                    // Add new task to the database
                    _unitOfWork.Comment.Add(newTask);
                    await _unitOfWork.SaveChangesAsync();

                    // Return the saved task DTO
                    return new Commanddto
                    {
                        TaskID = newTask.TaskID,
                        Content = newTask.Content,
                        UserID = newTask.UserID,
                        Status = newTask.Status,
                        Timestamp = newTask.Timestamp
                    };


                }
                else
                {
                    // Update existing task
                    var existingTask = await _unitOfWork.Comment.FindAsync(commanddto.CommentID);
                    if (existingTask == null)
                    {
                        // Set default error response if task is not found
                        return null;
                    }

                    // Update task properties
                    existingTask.TaskID = commanddto.TaskID;
                    existingTask.Content = commanddto.Content;
                    existingTask.UserID = commanddto.UserID;
                    existingTask.Status = commanddto.Status;
                    existingTask.Timestamp = commanddto.Timestamp;
                    // Update task in the database
                    _unitOfWork.Comment.Update(existingTask);
                    await _unitOfWork.SaveChangesAsync();

                    // Return the updated task DTO
                    return new Commanddto
                    {
                        TaskID = existingTask.TaskID,
                        Content = existingTask.Content,
                        UserID = existingTask.UserID,
                        Status = existingTask.Status,
                        Timestamp = existingTask.Timestamp
                    };
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteCommentById(int id)
        {
            try
            {
                // Retrieve the task by ID from the database context
                var task = await _unitOfWork.Comment.FindAsync(id);

                if (task == null)
                {
                    throw new Exception("Task not found");
                }

                // Remove the task from the context
                _unitOfWork.Comment.Remove(task);

                // Save changes to the database
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}