//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR_14_KILE.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sklad
    {
        public int id { get; set; }
        public string naimenov { get; set; }
        public int kolichestvo { get; set; }
        public decimal cena { get; set; }
        public int TypeID { get; set; }
    
        public virtual Type Type { get; set; }
    }
}
