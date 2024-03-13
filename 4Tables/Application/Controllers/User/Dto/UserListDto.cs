namespace _4Tables.Application.Controllers.User.Dto
{
    public record UserListDto(Guid id, string email, string firstName, string lastName, bool available)
    {
    }
}
