using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScallopShellProject.Models;
using ScallopShellProject.SessionModel;
using DataProj.Models;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;
using System.Net;
using System.Web;

namespace ScallopShellProject.Controllers
{
    public class CheckoutController : Controller
                
    {
        private readonly ArticleRepository _articleRepository;


        private readonly UserSiteRepository _userSiteRepository;

        private readonly EncomendaCabecRepository _EncomendaCabecRepository;

        private readonly EncomendaLinhaRepository _EncomendaLinhaRepository;



        public CheckoutController(ArticleRepository articleRepository,UserSiteRepository userSiteRepository,EncomendaCabecRepository encomendaCabecRepository,EncomendaLinhaRepository encomendaLinhaRepository)


        {
            _articleRepository = articleRepository;
            _userSiteRepository = userSiteRepository;
            _EncomendaCabecRepository = encomendaCabecRepository;
            _EncomendaLinhaRepository = encomendaLinhaRepository;

        }


        public IActionResult Index()
        {



            CheckoutViewModel checkoutView = new CheckoutViewModel();

            var Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            if (Cart == null)
            {
                Cart cartIni = new Cart();

                cartIni.ArticleList = cartIni.ArticleList = new List<Article>();
                HttpContext.Session.SetObjectAsJson("Cart", cartIni);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartIni);


            }

            Cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");

            checkoutView.Cart = Cart;

            return View(checkoutView);
        }


        public async Task<IActionResult> SaveCheckoutForm(CheckoutViewModel checkout)
        {


            try
            {

                if (string.IsNullOrEmpty(checkout.Cidade))
                {
                    throw new Exception("Preenche a cidade");
                }

                if (string.IsNullOrEmpty(checkout.CodPostal))
                {
                    throw new Exception("Preenche o código postal");
                }


                if (string.IsNullOrEmpty(checkout.Email))
                {
                    throw new Exception("Preenche o email");
                }


                if (string.IsNullOrEmpty(checkout.Morada))
                {
                    throw new Exception("Preenche a morada");
                }


                if (string.IsNullOrEmpty(checkout.Nome))
                {
                    throw new Exception("Preenche o nome");
                }


                if (string.IsNullOrEmpty(checkout.Telefone.ToString()))
                {
                    throw new Exception("Preenche o telefone");
                }

                if (string.IsNullOrEmpty(checkout.Nome.ToString()))
                {
                    throw new Exception("Preenche o Nome");
                }




                if (checkout.ListIdArticle==null)
                {
                    return RedirectToAction("Index", "Home");
                }

                if (checkout.Comentario == null)
                {
                    checkout.Comentario = "N/A";
                }



                checkout.ListArticles=_articleRepository.GetArticlesByListId(checkout.ListIdArticle);


            
                //Extracao do user
                UserSite objUsersite = new UserSite();
                objUsersite.Email = checkout.Email;
                _userSiteRepository.SaveUser(objUsersite);


                //Extracao do cabec

                EncomendaCabec ObjencomendaCabec = new EncomendaCabec();
                ObjencomendaCabec.Id = Guid.NewGuid();
                ObjencomendaCabec.CodPostal = checkout.CodPostal;
                ObjencomendaCabec.Localidade = checkout.Cidade;
                ObjencomendaCabec.Morada = checkout.Morada;
                ObjencomendaCabec.Payment = false;
                ObjencomendaCabec.Descricao = checkout.Comentario;
                ObjencomendaCabec.NomeUtilizador = checkout.Nome;
                ObjencomendaCabec.IdUserSite = _userSiteRepository.getUserByEmail(checkout.Email).Id;
                _EncomendaCabecRepository.SaveEncomendaLinha(ObjencomendaCabec);

                //Extracao do linhacabec

                string addLine = " <tbody>";

                foreach (var item in checkout.ListArticles)
                {
                    EncomendaLinha ObjencomendaLinha = new EncomendaLinha();
                    ObjencomendaLinha.Qty = 1;
                    ObjencomendaLinha.DateCreation = DateTime.Now;
                    ObjencomendaLinha.UserCreation = checkout.Email;
                    ObjencomendaLinha.IdEncomendaCabec = ObjencomendaCabec.Id;
                   
                    ObjencomendaLinha.PrecoUnit = item.PrecoUnit;
                    ObjencomendaLinha.Qty = 1;
                    ObjencomendaLinha.ArticleID = item.Id;
                    ObjencomendaLinha.Article = item;
                    var base64 = Convert.ToBase64String(item.ImageList[0].ImageByte);
                    var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                    addLine = addLine + "<tr> <td> "+item.Descricao+ "  </td> <td>" + item.PrecoUnit.ToString("0.00") + "</td>  <td>" + item.PrecoUnit.ToString("0.00")+ " +  </td> <td> <img width='100px' height='100px' src='"+ imgSrc + "'>   </td> </tr>";



                    _EncomendaLinhaRepository.SaveEncomendaLinha(ObjencomendaLinha);
                }
                try
                {
                    addLine = addLine + "</tbody>";



                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("zapafta@gmail.com");
                mailMessage.To.Add("renatofrancisco92@gmail.com");
                    mailMessage.To.Add("elisabetevieira94@hotmail.com ");
                    mailMessage.Body = "body";
                mailMessage.IsBodyHtml = true;



                    var newbo = await RenderViewToStringAsync(this, "EmailFirst");

                    newbo = newbo.Replace("ZACAID", ObjencomendaCabec.Id.ToString().Trim().ToUpper()) ;
                    newbo = newbo.Replace("ZACAUtilizador", ObjencomendaCabec.NomeUtilizador);
                    newbo = newbo.Replace("ZACALocalidade", ObjencomendaCabec.Localidade);
                    newbo = newbo.Replace("ZACALocalidade", ObjencomendaCabec.Localidade);
                    newbo = newbo.Replace("ZACATotal", checkout.ListArticles.Sum(item => item.PrecoUnit).ToString("0.00"));
                    newbo = newbo.Replace("ZACALinhas", addLine);

                    mailMessage.Body = newbo;
                    foreach (var item in checkout.ListArticles)
                    {

                    }



                    mailMessage.Subject = "Nota de encomenda - ScallopShell";
   

                    using (var client = new SmtpClient("smtp.gmail.com"))
                    {
                        client.Port = 587;
                        client.Credentials = new NetworkCredential("zapafta@gmail.com", "xDxD1992");
                        client.EnableSsl = true;
                        client.TargetName = "Zapafta";
                        client.Send(mailMessage);
                    }


                }
                catch (Exception ex)
                {

                    ex.Message.ToString();
                }

                return View(checkout);

            }
            catch (Exception ex)
            {
                checkout.Error = ex.Message;


                return View(checkout);
            }


        }

        //public async Task<int> MandarEmail(string Subjec)
        //{
        //    var smtpClient = new SmtpClient
        //    {
        //        Host ="smtp.gmail.com", // set your SMTP server name here
        //        Port = 465, // Port 
        //        EnableSsl = true,
        //        Credentials = new NetworkCredential("zapafta@gmail.com", "xDxD1992")
        //    };
        //    var newbo = await RenderViewToStringAsync(this, "EmailFirst");
     
        //    using (var message = new MailMessage("zapafta@gmail.com", To)
        //    {
        //        Subject = Subjec,
        //        Body = newbo,
        //        IsBodyHtml = true
        //    })
        //    {
        //        await smtpClient.SendMailAsync(message);
        //    }
        //    return 1;
        //}
        public string ConvertHTML(List<Article> list, EncomendaCabec encomendaCabec)
        {
            string web = "";

        
            return "";
        }


        public static async Task<string> RenderViewToStringAsync(Controller controller, string viewNamePath)
        {
            if (string.IsNullOrEmpty(viewNamePath))
                viewNamePath = controller.ControllerContext.ActionDescriptor.ActionName;


            using (StringWriter writer = new StringWriter())
            {
                try
                {
                    IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;

                    ViewEngineResult viewResult = null;

                    if (viewNamePath.EndsWith(".cshtml"))
                        viewResult = viewEngine.GetView(viewNamePath, viewNamePath, false);
                    else
                        viewResult = viewEngine.FindView(controller.ControllerContext, viewNamePath, false);

                    if (!viewResult.Success)
                        return $"A view with the name '{viewNamePath}' could not be found";

                    ViewContext viewContext = new ViewContext(
                        controller.ControllerContext,
                        viewResult.View,
                        controller.ViewData,
                        controller.TempData,
                        writer,
                        new HtmlHelperOptions()
                    );

                    await viewResult.View.RenderAsync(viewContext);

                    return writer.GetStringBuilder().ToString();
                }
                catch (Exception exc)
                {
                    return $"Failed - {exc.Message}";
                }
            }
        }
    }
}