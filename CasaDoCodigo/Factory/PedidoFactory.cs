using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Factory
{
    public class PedidoFactory
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public PedidoFactory(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Pedido Criar()
        {
            Pedido pedido;
            //checa se pedido já existe na session
            var pedidoSession = _contextAccessor.HttpContext.Session.GetString("pedido");
            if (string.IsNullOrWhiteSpace(pedidoSession))
            {
                pedido = new Pedido();
            }
            else
            {
                pedido = JsonConvert.DeserializeObject<Pedido>(pedidoSession);
            }
            return pedido;
        }
    }
}
