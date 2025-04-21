window.initSortable = (dotNetHelper) => {
    document.querySelectorAll('.tree-children').forEach(group => {
        new Sortable(group, {
            group: 'shared',
            animation: 150,
            handle: '.drag-handle',
            fallbackOnBody: true,
            swapThreshold: 0.65,
            ghostClass: 'sortable-ghost',
            onStart(evt) {
                // Store the initial state or data if needed
            },
            onEnd(evt) {
                // Prevent Sortable.js from updating the DOM
                evt.from.insertBefore(evt.item, evt.from.children[evt.oldIndex]);
                // Notify Blazor to update the data model
                dotNetHelper.invokeMethodAsync('OnItemDropped', evt.item.dataset.id, evt.to.dataset.id, evt.newIndex);
            }
        });
    });
};
