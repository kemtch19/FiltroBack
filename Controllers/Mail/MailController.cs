using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FiltroBack.Models;

namespace FiltroBack.Controllers.Mail
{
    public class MailController
    {
        public async void SendEmail(string emailOwner, string nameOwner, DateTime? dateQuote, string Description, string nameVet, string phoneVet, string emailVet, string namePet)
        {   
            try
            {
                /* Url proporcionada por mailersend */
                string url = "https://api.mailersend.com/v1/email";

                // Token para autorización del mailersend
                string jwtToken = "mlsn.9a86bc451369998ba89de0b6c8e73782b348ea47cf903885ee3eed472baff82d";

                /* Colocamos el mensaje del email */
                var EmailMessage = new Email
                {
                    /* Email que proporciona MailerSend */
                    from = new From { email = "MS_GXlEIi@trial-jpzkmgqy0dyl059v.mlsender.net"},

                    /* A que persona se le va a enviar el email */
                    to = [
                        new To {email = emailOwner}
                    ],

                    /* Asunto del correo */
                    subject = $"Hola!, Tienes cita pendiente para tu mascota : {namePet}", 

                    // Cuerpo del correo
                    text= $"Hola!, {nameOwner} recientemente haz hecho una cita con el veterinario {nameVet}, para tu mascota {namePet} la cual tiene esta descripción en su historial {Description}. Tu cita es para {dateQuote}, si deseas mas información te puedes comunicar con tu veterinario {emailVet}, {phoneVet}"
                };

                /* Serializar el email */
                string jsonBody = JsonSerializer.Serialize(EmailMessage);

                 // Config cliente que va a enviar el correo
                using(HttpClient client = new HttpClient())
                {
                    // Autorización por el token del jwt
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    // Respuesta que nos devuelve
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Verificación de la respuesta en que casos no sirve y que se puede mostrar
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Se ha enviado correctamente el correo a {emailOwner} con el asunto:\n{EmailMessage.text}");
                    } else
                    {
                        Console.WriteLine($"La solicitud falló: {response.StatusCode}");
                    }
                }
            }
            catch (Exception e) {}
        }
    }
}