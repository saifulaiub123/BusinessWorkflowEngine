﻿namespace BWE.Domain.IEntity
{
    internal interface IBaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
