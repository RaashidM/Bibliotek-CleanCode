﻿using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Author>
    {
        public CreateAuthorCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        
    }
}
