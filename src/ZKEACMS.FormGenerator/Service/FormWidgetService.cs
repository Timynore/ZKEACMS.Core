using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easy;
using ZKEACMS.Widget;
using ZKEACMS.FormGenerator.Models;
using Microsoft.AspNetCore.Mvc;

namespace ZKEACMS.FormGenerator.Service
{
    public class FormWidgetService : SimpleWidgetService<FormWidget>
    {
        private readonly IFormService _formService;
        public FormWidgetService(IWidgetBasePartService widgetBasePartService,
            IApplicationContext applicationContext,
            CMSDbContext dbContext,
            IFormService formService)
            : base(widgetBasePartService, applicationContext, dbContext)
        {
            _formService = formService;
        }

        public override WidgetViewModelPart Display(WidgetDisplayContext widgetDisplayContext)
        {
            Form form = _formService.Get((widgetDisplayContext.Widget as FormWidget).FormID);
            return widgetDisplayContext.ToWidgetViewModelPart(form);
        }
    }
}
