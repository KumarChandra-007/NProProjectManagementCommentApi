using NproProjectManagement.CommandDTO;


namespace NproProjectManagement.Interfaces
{
    public interface ICommentManagementServices
    {
        Task<List<Commanddto>> GetCommentDetails();
        Task<List<Commanddto>> GetCommentDetailById(int id);
        Task<Commanddto> SaveCommentDetail(Commanddto Commanddto);
        Task DeleteCommentById(int id);
    }
}
