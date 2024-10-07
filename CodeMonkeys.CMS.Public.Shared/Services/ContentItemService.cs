﻿using CodeMonkeys.CMS.Public.Shared.Entities;
using CodeMonkeys.CMS.Public.Shared.Repository;

namespace CodeMonkeys.CMS.Public.Shared.Services
{
    public class ContentItemService(ContentItemRepository repository) : IContentItemService
    {
        // ContentItem lists
        public ContentItem? DraggedContentItem { get; private set; }
        private ContentItemRepository _repository = repository;

        // Add a new ContentItem item to a specific list
        public async Task AddContentItemAsync(ContentItem contentItem) => await _repository.AddContentItemAsync(contentItem);
        public async Task DeleteContentItemAsync(ContentItem contentItem) => await _repository.DeleteContentItemAsync(contentItem);
        public async Task UpdateContentItemAsync(ContentItem contentItem) => await _repository.UpdateContentItemAsync(contentItem);
        public async Task<IEnumerable<ContentItem>> GetContentItemsAsync(IEnumerable<ContentItem> contentItems) => await _repository.GetContentItemsAsync(contentItems);
        public async Task<IEnumerable<ContentItem>> GetContentItemsAsync(IEnumerable<int> contentItemIds) => await _repository.GetContentItemsAsync(contentItemIds);
        public async Task<IEnumerable<ContentItem>> GetContentItemsAsync(IEnumerable<Section> sections) => await _repository.GetContentItemsAsync(sections);
        public async Task<IEnumerable<ContentItem>> GetContentItemsAsync(int sectionId) => await _repository.GetContentItemsAsync(sectionId);


        // Get sections and their ContentItem items if they exist; otherwise, create a new section
        public async Task<Dictionary<int, Section>> GetSectionContentItemsAsync(int webPageId)
        {
            return await _repository.GetSectionContentItemsAsync(webPageId);
        }

        // Start dragging a ContentItem item
        public void StartDrag(ContentItem contentItem)
        {
            DraggedContentItem = contentItem;
        }

        // Drop the dragged ContentItem item into the target list
        public async Task MoveContentItemAsync(int newSectionId)
        {
            if (DraggedContentItem != null)
            {
                DraggedContentItem.SectionId = newSectionId;

                await _repository.UpdateContentItemAsync(DraggedContentItem);
                DraggedContentItem = null;
            }
        }

        public async Task RemoveContentItemAsync(ContentItem contentItem)
        {
            await _repository.DeleteContentItemAsync(contentItem);
        }
        
        public async Task UpdateSectionIdAsync(int contentItemId, int newSectionId)
        {
            var contentItem = await _repository.GetContentItemByIdAsync(contentItemId);
            if (contentItem != null)
            {
                contentItem.SectionId = newSectionId;
                await _repository.UpdateContentItemAsync(contentItem);
            }
        }

       public async Task UpdateSortOrderAsync(int contentId, int sortOrder)
{
    // Logga anropet
    Console.WriteLine($"Updating sort order for ContentId: {contentId} to SortOrder: {sortOrder}");
    
    var contentItem = await _repository.ContentItems.FindAsync(contentId);
    if (contentItem != null)
    {
        contentItem.SortOrder = sortOrder;
        await _repository.SaveChangesAsync();
    }
    else
    {
        Console.WriteLine($"ContentItem with ContentId: {contentId} not found.");
    }
}


       

    }
}