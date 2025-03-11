using Microsoft.AspNetCore.Mvc;
using MyEshop.Data;
using MyEshop.Data.Repositories;
using MyEshop.Models;

namespace MyEshop.Components
{
    public class ProductGroupsComponent : ViewComponent
    {

        IGroupRepository _groupRepository;

        public ProductGroupsComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ProductGroupsComponent.cshtml",_groupRepository.GetGroupForShow());
        }
    }
}
