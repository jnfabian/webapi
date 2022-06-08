using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace webapi.Models
{
    public class ClienteBEValidator : AbstractValidator<ClienteBE>
    {
        public ClienteBEValidator()
        {
            RuleFor(x => x.CodCliente)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.NombreCompleto)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.NombreCorto)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Abreviatura)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Ruc)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Estado)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.GrupoFacturacion)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.InactivoDesde)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.CodigoSAP)
                .NotNull()
                .NotEmpty();

        }
    }
}
