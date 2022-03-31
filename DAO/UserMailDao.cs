using aljuvifoods_webapi.Repository;
using aljuvifoods_webapi.Services;
using aljuvifoods_webapi.Services.Contracts;

namespace aljuvifoods_webapi.DAO
{
    public class UserMailDao:IMailDao
    {
        private readonly ApplicationDbContext _context;

        public UserMailDao(ApplicationDbContext context)
        {
            _context = context;
        }

        public string SendMail(string email)
        {
            var queryName = from n in _context.Users
                            select n.Name;

            var queryMail = from n in _context.Users
                            where n.Email == email
                            select n.Email;

            var usr = "";
            foreach (var i in queryName)
            {
                Console.WriteLine(i);
                usr = i;
            }
            var mailService = new SupportMail();
            mailService.Send(
                subject: "Aljuvi Foods: Orden de pedido",
                body: "Hola, " + usr + "\nSu pedido ha sido concretado, en un momento llegara a su destino\n"
                + "Estos son los datos de tu orden\n"


                ,
                recipien: queryMail.ToList()
                );
            return "comprueba el eamil";
        }
    }
}
