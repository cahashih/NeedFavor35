//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hakaton
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhotoCompletedService
    {
        public int AnnouncementServiceId { get; set; }
        public string PhotoPath { get; set; }
        public string Author { get; set; }
    
        public virtual AnnouncementService AnnouncementService { get; set; }
    }
}
