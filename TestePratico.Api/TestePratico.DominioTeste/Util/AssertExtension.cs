﻿using System;
using Xunit;

namespace TestePratico.DominioTeste.Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this ArgumentException exception, string mensagem)
        {
            if (exception.Message == mensagem)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"Esperava a mensagem '{mensagem}'");
            }
        }
    }
}
