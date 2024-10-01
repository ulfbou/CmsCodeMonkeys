﻿using CodeMonkeys.CMS.Public.Components.Shared;
using CodeMonkeys.CMS.Public.Shared.Entities;
using CodeMonkeys.CMS.Public.Shared.Services;

using Microsoft.AspNetCore.Components;

namespace CodeMonkeys.CMS.Public.Components.Pages.ContentItems
{
    public partial class ContentItems : AuthenticationBaseComponent<ContentItems>
    {
        [Parameter] public int WebPageId { get; set; }
        public WebPage WebPage { get; set; }

        [Parameter] public int SiteId { get; set; }
        public WebPage Site { get; set; }

        [Inject] IContentItemService ContentItemService { get; set; }
        [Inject] ISectionService SectionService { get; set; }

        private Dictionary<int, Section> _sections = new();
        private Section _section1;
        private Section _section2;
        private Section _section3;
        private Section _section4;
        private int _sectionId1;
        private int _sectionId2;
        private int _sectionId3;
        private int _sectionId4;

        // private ContentItemStorage ContentItemStorage { get; set; }
        private string newContentItemText = string.Empty;
        private int selectedList = 1;

        private bool showColorPicker = false;
        private string selectedColor = "White";
        private int currentBox = 1;
        private string selectedBox = "Box 1";

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            try
            {
                await LoadSectionsAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error loading content items for web page {0}", WebPageId);
            }
        }

        private async Task LoadSectionsAsync()
        {
            _section1 = await EnsureSectionAsync(SectionNames.Header.ToString());
            _section2 = await EnsureSectionAsync(SectionNames.Body.ToString());
            _section4 = await EnsureSectionAsync(SectionNames.Footer.ToString());
            _section3 = new Section { SectionId = 0, Name = "Toolbar", Color = "#fefefe", WebPageId = WebPageId };

            _sections = new()
            {
                { _section1.SectionId, _section1 },
                { _section2.SectionId, _section2 },
                { _section3.SectionId, _section3 },
                { _section4.SectionId, _section4 }
            };
        }

        private async Task<Section> EnsureSectionAsync(string name)
        {
            var section = await SectionService.GetSectionByNameAsync(WebPageId, name);
            if (section == null)
            {
                section = new Section { Name = name, Color = "#fefefe", WebPageId = WebPageId };
                section = await SectionService.CreateSectionAsync(section)
                    ?? throw new InvalidOperationException($"Error creating section: {name}");
            }
            return section;
        }

        private async Task ResetSectionsAsync()
        {
            await SectionService.DropWebPageSectionsAsync(WebPageId);
            await LoadSectionsAsync();
        }

        private void OpenColorPicker(int boxNumber)
        {
            if (currentBox == boxNumber && showColorPicker)
            {
                showColorPicker = false;
            }
            else
            {
                currentBox = boxNumber;
                if (_sections.TryGetValue(boxNumber, out var section))
                {
                    selectedBox = section.Name;
                    selectedColor = section.Color;
                }
                else
                {
                    selectedBox = "Box 1";
                    selectedColor = "#fefefe";
                }

                showColorPicker = true;
            }
        }

        private async Task SaveColorAsync()
        {
            await SectionService.SaveSectionColorAsync(currentBox, selectedColor);
            showColorPicker = false;
            StateHasChanged();
        }

        private async Task AddContentItem()
        {
            if (!string.IsNullOrWhiteSpace(newContentItemText))
            {
                var contentItems = _sections[selectedList]?.ContentItems ?? [];
                var contentItem = new ContentItem
                {
                    SectionId = selectedList,
                    Text = newContentItemText,
                    Title = newContentItemText,
                    Body = newContentItemText,
                    OrdinalNumber = contentItems.Count(),
                    AuthorId = User!.Id,
                    WebPageId = WebPageId
                };

                await ContentItemService.AddContentItemAsync(contentItem);
                await LoadSectionsAsync();
                newContentItemText = string.Empty;

                // Kontrollera och ställ in ShowEditButton endast om listan inte är tom
                ResetShowEditButton(_section1);
                ResetShowEditButton(_section2);
                ResetShowEditButton(_section3);
                ResetShowEditButton(_section4);
                StateHasChanged();
            }
        }

        private void ResetShowEditButton(Section section1)
        {
            if (section1.ContentItems.Any())
            {
                section1.ContentItems.Last().ShowEditButton = false;
            }
        }

        private void OnDragStart(ContentItem contentItem)
        {
            ContentItemService.StartDrag(contentItem);
        }

        private void OnDrop(int targetListNumber)
        {
            ContentItemService.DropContentItemAsync(WebPageId, targetListNumber).Wait();
            StateHasChanged();
        }

        private void ToggleEdit(ContentItem contentItem)
        {
            contentItem.ShowEditButton = !contentItem.ShowEditButton; // Toggle the edit button visibility
            StateHasChanged();
        }

        private void StartEdit(ContentItem contentItem)
        {
            contentItem.IsEditing = true;
            contentItem.ShowEditButton = false; // Hide the "Ändra" button
            StateHasChanged();
        }

        private void SaveEdit(ContentItem contentItem)
        {
            contentItem.IsEditing = false; // Save the edit and close the input field
            StateHasChanged();
        }

        private async Task RemoveContentItemAsync(ContentItem contentItem)
        {
            await ContentItemService.RemoveContentItemAsync(contentItem);
            await LoadSectionsAsync();
            StateHasChanged();
        }

        private void ChangeFontSize(ContentItem contentItem, int change)
        {
            contentItem.FontSize += change * 2; // Increase or decrease size by 10 pixels
            if (contentItem.FontSize < 10) // Minimum size
            {
                contentItem.FontSize = 10;
            }
            StateHasChanged();
        }

        private void ClearAll()
        {
            ResetSectionsAsync().Wait();

            StateHasChanged();
        }

        private Dictionary<string, string> colorOptions = new Dictionary<string, string>
            {
                { "Black", "#000000" },
                { "White", "#FFFFFF" },
                { "Red", "#FF0000" },
                { "Green", "#008000" },
                { "Blue", "#0000FF" },
                { "Yellow", "#FFFF00" },
                { "Orange", "#FFA500" },
                { "Purple", "#800080" },
                { "Pink", "#FFC0CB" },
                { "Brown", "#A52A2A" },
                { "Gray", "#808080" },
                { "Cyan", "#00FFFF" },
                { "Magenta", "#FF00FF" },
                { "LightBlue", "#ADD8E6" },
                { "DarkBlue", "#00008B" },
                { "DarkGreen", "#006400" },
                { "LightGreen", "#90EE90" },
                { "LightGray", "#D3D3D3" },
                { "Gold", "#FFD700" },
                { "Silver", "#C0C0C0" },
                { "Teal", "#008080" }
            };

        private Dictionary<string, string> fontFamilyOptions = new Dictionary<string, string>
            {
                { "Arial", "Arial, sans-serif" },
                { "Verdana", "Verdana, sans-serif" },
                { "Tahoma", "Tahoma, sans-serif" },
                { "Times New Roman", "'Times New Roman', serif" },
                { "Georgia", "Georgia, serif" },
                { "Courier New", "'Courier New', monospace" },
                { "Comic Sans MS", "'Comic Sans MS', cursive" },
                { "Impact", "Impact, sans-serif" },
                { "Lucida Console", "'Lucida Console', monospace" },
                { "Trebuchet MS", "'Trebuchet MS', sans-serif" },
                { "Palatino Linotype", "'Palatino Linotype', serif" },
                { "Garamond", "Garamond, serif" },
                { "Frank Ruhl Libre", "'Frank Ruhl Libre', serif" },
                { "Arial Black", "'Arial Black', sans-serif" },
                { "Futura", "Futura, sans-serif" },
                { "Droid Sans", "'Droid Sans', sans-serif" },
                { "Segoe UI", "'Segoe UI', sans-serif" },
                { "Roboto", "'Roboto', sans-serif" },
                { "Open Sans", "'Open Sans', sans-serif" },
                { "Montserrat", "'Montserrat', sans-serif" },
                { "Lato", "'Lato', sans-serif" }
            };
    }
    public enum SectionNames
    {
        Header,
        Body,
        Footer,
        Toolbar
    }
}