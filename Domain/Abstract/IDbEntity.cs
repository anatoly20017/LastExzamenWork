using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Abstract
{
  public interface IDbEntity
  {
    [Key]
    Guid Id { get; set; }
  }
}