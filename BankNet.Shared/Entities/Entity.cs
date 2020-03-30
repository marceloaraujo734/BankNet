using System;
using FluentValidator;

namespace BankNet.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity() => this.Id = Guid.NewGuid();
        
        public Guid Id { get; private set; }

    }
}
