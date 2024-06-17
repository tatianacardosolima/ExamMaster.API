using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Users
{
    public class UserEntity : EntityBase
    {
        public string Name { get => GetProperty<string>(); private set => SetProperty(value); }

        public UserEntity(string name)
        {
            Name = name;
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
