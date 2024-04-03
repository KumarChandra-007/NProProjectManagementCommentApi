using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NproProjectManagement.Interfaces;
using NproProjectManagement.Services;
using NproProjectManagement.CommandDTO;


namespace NproProjectManagement.Controllers
{
    [Route("commentapi")]
    [ApiController]

    public class CommentManagementController : ControllerBase
    {
        private readonly ICommentManagementServices _commentManagementServices;
        public CommentManagementController(ICommentManagementServices commentManagementServices)
        {
            _commentManagementServices = commentManagementServices;
        }

        [HttpGet("GetCommentDetails")]
        public async Task<ActionResult<List<Commanddto>>> GetCommentDetails()
        {
            try
            {
                // Retrieve the list of task details from the service
                var CommentDetails = await _commentManagementServices.GetCommentDetails();
                // Return the task details as a success response
                return Ok(CommentDetails);
            }
            catch (Exception ex)
            {
                // Return an error response if an exception occurs during processing
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/TaskManagement/GetTaskDetailById?id={id}
        [HttpGet("GetCommentDetailById/{commentId}")]
        public async Task<ActionResult<List<Commanddto>>> GetCommentDetailById(int commentId)
        {
            try
            {
                // Retrieve the task details by ID from the service
                var CommentkDetails = await _commentManagementServices.GetCommentDetailById(commentId);
                // Return the task details as a success response
                return Ok(CommentkDetails);
            }
            catch (Exception ex)
            {
                // Return an error response if an exception occurs during processing
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/TaskManagement/GetCommentDetailByTaskId?id={id}
        [HttpGet("GetCommentDetailByTaskId/{taskId}")]
        public async Task<ActionResult<List<Commanddto>>> GetCommentDetailByTaskId(int taskId)
        {
            try
            {
                // Retrieve the task details by ID from the service
                var CommentkDetails = await _commentManagementServices.GetCommentDetailById(taskId);
                // Return the task details as a success response
                return Ok(CommentkDetails);
            }
            catch (Exception ex)
            {
                // Return an error response if an exception occurs during processing
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("SaveCommentDetail")]
        public async Task<ActionResult> SaveCommentDetail(Commanddto commanddto)
        {
            try
            {
                // Save the task details using the provided DTO
                await _commentManagementServices.SaveCommentDetail(commanddto);
                // Return a success response
                return Ok("Comment saved successfully");
            }
            catch (Exception ex)
            {
                // Return an error response if an exception occurs during processing
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteCommentById")]
        public async Task<ActionResult> DeleteCommentById(int id)
        {
            try
            {
                // Delete the task by ID
                await _commentManagementServices.DeleteCommentById(id);
                // Return a success response
                return Ok("Task deleted successfully");
            }
            catch (Exception ex)
            {
                // Return an error response if an exception occurs during processing
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}