﻿namespace ConsoleApp1.Models;

public class Sale
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ShowroomId { get; set; } // идентификатор салона в котором произошла продажа
    public Guid CarId { get; set; } // идентификатор машины которая была продана
    public Guid UserId { get; set; } // идентификатор пользователя который продал машину
    public DateTime  SaleDate { get; set; } // дата продажи
    public decimal SalePrice { get; set; } // стоимость продажи
    
    public string Make { get; set; } // название бренда авто
    
    public string Model { get; set; } // название модели авто
}