window.treeDragDrop = {
    init: function (treeRoot, dotNetHelper) {
        console.log("🧩 JS initialized");

        const buildTree = (ulElement) => {
            const tree = [];

            ulElement.querySelectorAll(':scope > li').forEach(li => {
                const id = li.getAttribute('data-id');
                const title = li.querySelector(':scope > .drag-handle')?.textContent.trim() || "";

                const childUl = li.querySelector(':scope > ul');
                const children = childUl ? buildTree(childUl) : [];

                if (id) {
                    tree.push({ id, title, children });
                } else {
                    console.warn("⚠️ Skipped node with no data-id");
                }
            });

            return tree;
        };

        const makeSortable = (ul) => {
            new Sortable(ul, {
                group: 'nested',
                handle: '.drag-handle',
                animation: 150,
                fallbackOnBody: false, // ⚠️ prevent DOM clone
                onEnd: () => {
                    const rootUl = treeRoot.querySelector('ul.sortable');
                    const updatedTree = buildTree(rootUl);
                    console.log("📤 Sending updated tree to Blazor:", updatedTree);
                    dotNetHelper.invokeMethodAsync('OnTreeUpdated', JSON.stringify(updatedTree));
                }
            });

            // recursively enable nested ULs
            ul.querySelectorAll(':scope > li > ul').forEach(makeSortable);
        };

        const rootUl = treeRoot.querySelector('ul.sortable');
        if (rootUl) {
            makeSortable(rootUl);
        } else {
            console.warn("⚠️ Root UL not found.");
        }
    }

};
