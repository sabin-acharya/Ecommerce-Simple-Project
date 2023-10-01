using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using MimeKit;
using NuGet.Protocol.Plugins;
using Shopping.Models;
using System.Net.Mail;
using MailKit.Net.Smtp;
using System.Runtime.InteropServices;
using EmailModel = Shopping.Models.EmailModel;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Humanizer;
using Shopping.Repository.Class;
using Shopping.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Shopping.Data;

namespace Shopping.Services
{
    public class EmailServicesRepo : RepositoryRepo<EmailModel>, IEmailServicesRepo
    {
        private readonly EmailModel _emailmodel;
        private readonly ISmtpClient _smtpclient;
        private readonly ApplicationDbContext _context;

        public EmailServicesRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public EmailServicesRepo(ApplicationDbContext context, ISmtpClient smtpclient, EmailModel emailmodel) : base(context)
        {
            
            _smtpclient = smtpclient;
            _emailmodel = emailmodel;
        }

       
        public void SendEmail(MessageModel message)
        {
            var emailMessage = CreateEmailMessage(message);
            SendEmail(message);

        }

        private MimeMessage CreateEmailMessage(MessageModel message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("email", _emailmodel.Email));
            email.To.AddRange(message.To);
            email.Subject = _emailmodel.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return email;
        }
        private void send(MimeMessage mimemessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailmodel.SenderAddress, _emailmodel.Port, true);
                client.AuthenticationMechanisms.Remove("xoauth2");
                client.Authenticate(_emailmodel.UserName, _emailmodel.Password);
                client.Send(mimemessage);
            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

       
    }
}
