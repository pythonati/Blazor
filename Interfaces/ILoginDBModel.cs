using FirstBlazor.OtherClasses.Enum;

namespace FirstBlazor.Interfaces
{
    public interface ILoginDBModel
    {
        public LoginResults Result { get; set; }
        public int UserId { get; set; }
    }
}
