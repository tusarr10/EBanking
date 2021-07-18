(function() {
    function onGridViewInit(s, e) {
        AddAdjustmentDelegate(adjustGridView);
        updateToolbarButtonsState();
    }
    function onGridViewSelectionChanged(s, e) {
        updateToolbarButtonsState();
    }
    function adjustGridView() {
        gridView.AdjustControl();
    }
    function updateToolbarButtonsState() {
        var enabled = gridView.GetSelectedRowCount() > 0;
        pageToolbar.GetItemByName("View").SetEnabled(enabled);
        pageToolbar.GetItemByName("Export").SetEnabled(enabled);
        pageToolbar.GetItemByName("Deposit").SetEnabled(enabled);
        pageToolbar.GetItemByName("Withdraw").SetEnabled(enabled);
    }
    function onPageToolbarItemClick(s, e) {
        switch(e.item.name) {
            case "ToggleFilterPanel":
                toggleFilterPanel();
                break;
            case "Deposit":
                DepositSelectedRecord();
                break;
            case "Withdraw":
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
        if (confirm('Do You Want To Withdraw... ')) {
            gridView.PerformCallback('withdraw');
        }
    }
    function DepositSelectedRecord() {
        if (confirm('Do You Want To Deposit... ')) {
            gridView.PerformCallback('deposit');
        }
    }
    function ViewSelectedRecord() {
        if (confirm('Do You Want To Open Profile... ')) {
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