// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FinalBlazorIndivisualUser.Client.Pages.PostComponents
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using FinalBlazorIndivisualUser.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using FinalBlazorIndivisualUser.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using FinalBlazorIndivisualUser.Client.Repositories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using FinalBlazorIndivisualUser.Shared.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\Pages\PostComponents\EditPost.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/post/edit/{Id:int}")]
    public partial class EditPost : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 73 "C:\Users\User\Desktop\FinalBlazorIndivisualUser\FinalBlazorIndivisualUser\Client\Pages\PostComponents\EditPost.razor"
       
    Post post;

    [Parameter]
    public int Id { get; set; }
    public string Message = null;
    public bool ShowMessage = false;
    List<Category> categories;
    public string CurrentUserId = null;
    private Task<AuthenticationState> authState;
    protected async override Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        CurrentUserId = authState.User.Claims.Where(p => p.Type == "CurrentUserId").Select(c => c.Value).FirstOrDefault();

        post = new Post();

        var myPostResult = await postRepository.GetPostWithId(Id);
        if (myPostResult.Status)
        {
            if (myPostResult.Response != null)
            {
                if (myPostResult.Response.UserId == CurrentUserId)
                {
                    post = myPostResult.Response;
                }else
                {
                    CurrentUserId = null;
                }

            }
        }
        else
        {
            ShowMessage = true;
            Message = "There is no such a post";
        }

        var result = await categoryRepository.GetCategories();
        if (result.Status)
        {
            if (result.Response != null && result.Response.Count > 0)
            {
                categories = result.Response;
            }
            else
            {
                categories = new List<Category>();
            }
        }
        else
        {
            categories = new List<Category>();
        }


    }

    private async Task EditThisPost()
    {
        if (post.CategoryId == 0)
        {
            ShowMessage = true;
            Message = "Category Field is required !";
        }
        else
        {
            var result = await postRepository.UpdatePost(post);
            ShowMessage = true;
            if (result.Status)
            {
                if (result.Response)
                {
                    Message = "Post has been edited successfuly";
                }
                else
                {
                    Message = "Failed to edit the post";
                }
            }
            else
            {
                Message = "Something went wrong ,try again";
            }
        }

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICategoryRepository categoryRepository { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IPostRepository postRepository { get; set; }
    }
}
#pragma warning restore 1591
