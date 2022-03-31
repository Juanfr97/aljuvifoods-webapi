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
            var queryMail = from n in _context.Users
                            where n.Email == email
                            select n.Email;

            var query =
                from u in _context.Users
                join o in _context.Orders on u.UserId equals o.UserId
                join op in _context.OrderProducts on o.Id equals op.OrderId
                join p in _context.Products on op.ProductId equals p.ProductId
                select new
                {
                    userName = u.Name + ", " + u.LastName,
                    userAddress = u.Street + ", " + u.City,
                    orderDesc = p.Description,
                    orderAmo = op.Amount,
                    orderDat = o.OrderDate,
                    orderTot = o.OrderTotal,
                };
            var auxOrder = "";
            var usr = "";
            foreach (var order in query)
            {
                usr = order.userName;
                auxOrder = $"Cliente : {usr}\n" +
                    $"Dirección : {order.userAddress}\n" +
                    $"Ordern : {order.orderDesc}\n " +
                    $"Cantidad : {order.orderAmo}\n  " +
                    $"Fecha pedido : {order.orderDat}\n Total : {order.orderTot}";
                Console.WriteLine(auxOrder);
            }
            var mailService = new SupportMail();
            mailService.Send(
                subject: "Aljuvi Foods: Orden",
                body: "Hola, " + usr + " Su pedido ha sido concretado, en un momento llegara a su domicilio\n"
                + "Estos son los datos de tu orden\n" + auxOrder,
                recipien: queryMail.ToList()
                );
            return "comprueba el email";
        }
    }
}
