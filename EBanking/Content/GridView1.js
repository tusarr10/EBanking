(function () {
    function onGridViewInit(s, e) {
        AddAdjustmentDelegate(adjustGridView);
        updateToolbarButtonsState();
    }
    function onGridViewSelectionChanged(s, e) {
        updateToolbarButtonsState();
        insertValueInLabel();
    }
    function insertValueInLabel() {
        try {
            var x = gridView.GetSelectedRowCount();
            //document.getElementById("").innerHTML = x;
            document.getElementById("selCount").innerHTML = gridView.GetSelectedRowCount();
        }
        catch (err) {
        }
    }
    function adjustGridView() {
        gridView.AdjustControl();
    }
    function updateToolbarButtonsState() {
        var enabled = gridView.GetSelectedRowCount() > 0;
        pageToolbar.GetItemByName("View").SetEnabled(enabled);
        pageToolbar.GetItemByName("Export").SetEnabled(enabled);
        //pageToolbar.GetItemByName("Send").SetEnabled(enabled);
        //pageToolbar.GetItemByName("SendAll").SetEnabled(enabled);
    }
    function onPageToolbarItemClick(s, e) {
        switch (e.item.name) {
            case "ToggleFilterPanel":
                toggleFilterPanel();
                break;
            case "Send":
                DepositSelectedRecord();
                break;
            case "SendAll":
                WithdrawSelectedRecord();
                break;
            case "View":
                ViewSelectedRecord();
                break;
            case "Export":
                gridView.ExportTo(ASPxClientGridViewExportFormat.Xlsx);
                break;
        }
    }

    function WithdrawSelectedRecord() {
        if (confirm('Do You Want To Transfer All Selected Document ... ')) {
            gridView.PerformCallback('SendAll');
        }
    }
    function DepositSelectedRecord() {
        if (confirm('Do You Want To Transfer First Document... ')) {
            gridView.PerformCallback('Send');
           // ShowDetails();
        }
    }
    function ViewSelectedRecord() {
        if (confirm('Not Yet Implement ... ')) {
            gridView.PerformCallback('view');
        }
    }
    function onFiltersNavBarItemClick(s, e) {
        var filters = {
            All: "",
            Active: "[Status] = 1",
            Bugs: "[Kind] = 1",
            Suggestions: "[Kind] = 2",
            HighPriority: "[Priority] = 1"
        };
        gridView.ApplyFilter(filters[e.item.name]);
        HideLeftPanelIfRequired();
    }

    function toggleFilterPanel() {
        filterPanel.Toggle();
    }

    function onFilterPanelExpanded(s, e) {
        adjustPageControls();
        searchButtonEdit.SetFocus();
    }

    window.onGridViewInit = onGridViewInit;
    window.onGridViewSelectionChanged = onGridViewSelectionChanged;
    window.onPageToolbarItemClick = onPageToolbarItemClick;
    window.onFilterPanelExpanded = onFilterPanelExpanded;
    window.onFiltersNavBarItemClick = onFiltersNavBarItemClick;
})();