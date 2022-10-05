namespace FullStack.Dtos
{
    public class SignupDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<ContactDetailsDto> ContactDetails { get; set; }
    }
}
