(function() {
    var DXDemo = {};
    DXDemo.HeaderHeight = 60;
    DXDemo.onOptionsDependentControlBeginCallback = function(s, e) {
        if(!window["jQuery"])
            return;
        var optionsContainer = $(".options-container")[0];
        if (optionsContainer) {
            ASPxClientControl.GetControlCollection()
                .GetControlsByType(ASPxClientEdit)
                .filter(function (editor) { return ASPxClientUtils.GetIsParent(optionsContainer, editor.GetMainElement()); })
                .forEach(function (editor) {
                    e.customArgs[editor.name] = editor.GetValue();
                });
        }
    };
    var isSmallScreen = function() {
        return window.innerWidth <= NavigationPanel.cpCollapseAtWindowInnerWidth;
    };
    DXDemo.toggleNavigationPanel = function() {
        if(!window.NavigationPanel)
            return;

        if(isSmallScreen()) {
            if(!NavigationPanel.GetVisible())
                NavigationPanel.SetVisible(true);
            if(!NavigationPanel.IsExpanded())
                DXDemo.moveControlSectionToBackground();
            NavigationPanel.Toggle();
        } else {
            NavigationPanel.SetVisible(!NavigationPanel.GetVisible());
            ASPx.GetControlCollection().ProcessControlsInContainer(document.getElementById('DemoArea'), function(control) {
                control.AdjustControl();
            });
        }
        DXDemo.adjustDemoSettingsBlock();
    };
    DXDemo.toggleThemeSettingsPanel = function() {
        if(!window.ThemeSettingsPanel)
            return;
        if(!ThemeSettingsPanel.IsExpanded())
            DXDemo.moveControlSectionToBackground();
		document.querySelector(".right-button-toggle-themes-panel").setAttribute("aria-pressed", !ThemeSettingsPanel.IsExpanded());
        ThemeSettingsPanel.Toggle();
    };

    DXDemo.onVerticalPanelCollapsed = function() {
        if((!window.ThemeSettingsPanel || !ThemeSettingsPanel.IsExpanded())
            && (!NavigationPanel || !NavigationPanel.IsExpanded() || !isSmallScreen()))
            DXDemo.restoreControlSectionFromBackground();
    };
    DXDemo.moveControlSectionToBackground = function() {
        var controlSection = document.getElementsByClassName("control-section")[0];
        ASPx.AddClassNameToElement(controlSection, "background");
    };
    DXDemo.restoreControlSectionFromBackground = function() {
        var controlSection = document.getElementsByClassName("control-section")[0];
        ASPx.RemoveClassNameFromElement(controlSection, "background");
    };

    DXDemo.adjustDemoSettingsBlock = function() {
        var demoSettings = document.getElementsByClassName('options-container')[0];
        if(!demoSettings || !demoSettings.style.width || demoSettings.style.width.indexOf('%') > -1)
            return;
        var controlArea = document.getElementsByClassName('control-area')[0];
        var demoArea = document.getElementById('DemoArea');
        var emptySpace = 32;

        if(demoArea.clientWidth <= (parseInt(demoSettings.style.width, 10) + controlArea.clientWidth))
            demoSettings.classList.add('bottom-block');
        else {
            demoSettings.classList.remove('bottom-block');
            var initialWidth = ASPx.Attr.GetAttribute(demoSettings, "data-initialWidth");
            demoSettings.style.width = initialWidth ? initialWidth : demoSettings.scrollWidth + 'px';
        }
    };

    DXDemo.focusSearch = function() {
        //SearchBox.Focus();
    };

    DXDemo.focusMainElement = function() {
        var mainElement = this.getElementByRole('main');

        if(mainElement) {
            var childElement = ASPx.FindFirstChildActionElement(mainElement, function(el) {
                return ASPx.Attr.GetAttribute(el.parentElement.parentElement, 'role') !== 'application' &&
                    ASPx.Attr.GetAttribute(el, 'id') !== null && el.className.indexOf('dxAIFE') == -1;
            });

            if(childElement)
                childElement.focus();
        }
    };

    DXDemo.getElementByRole = function(role) {
        var elements = document.getElementsByTagName(role);
        if(elements.length > 0)
            return elements[0];
        elements = document.getElementsByTagName('*');
        for(var i = 0; i < elements.length; i++) {
            if(elements[i].getAttribute('role') == role)
                return elements[i];
        }
    };

    DXDemo.toggleSkipLinks = function() {
        document.getElementById('skipLinks').classList.toggle('dxAIFE');
    };

    //DXDemo.CurrentDemoGroupKey = "";
    //DXDemo.CurrentDemoKey = "";
    DXDemo.CurrentThemeAspCookieKey = "DXCurrentTheme";
    DXDemo.CurrentDevExtremeThemeCookieKey = "DXCurrentDevExtremeTheme";
    DXDemo.CurrentBaseColorCookieKey = "DXCurrentBaseColor";
    DXDemo.CurrentAdaptiveThemeCookieKey = "DXCurrentAdaptiveTheme";
    DXDemo.CurrentAdaptiveBaseColorCookieKey = "DXCurrentAdaptiveBaseColor";
    DXDemo.CurrentFontCookieKey = "DXCurrentFont";
    //DXDemo.CodeLoaded = false;
    //DXDemo.ShowCodeInNewWindow = function(demoTitle, codeTitle){
    //    var codeWnd = window.open("", "_blank", "status=0,toolbar=0,scrollbars=1,resizable=1,top=74,left=74,width=" + (screen.availWidth - 150) + ",height=" + (screen.availHeight - 150));
    //    codeWnd.document.open();
    //    codeWnd.document.write("<html><head><title>");
    //    codeWnd.document.write(demoTitle + " - " + codeTitle);
    //    codeWnd.document.write("</title>");
    //    var links = document.getElementsByTagName("link");
    //    for(var i = 0; i < links.length; i++){
    //        if(links[i].href && links[i].href.indexOf("CodeFormatter.css") > -1){
    //            codeWnd.document.write("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + links[i].href + "\" />");
    //            break;
    //        }
    //    }
    //    codeWnd.document.write("</head><body><code>");
    //    var codeTab = DemoPageControl.GetTabByName(codeTitle);
    //    codeWnd.document.write(document.getElementById("CodeBlock" + (codeTab.index - 1)).innerHTML);
    //    codeWnd.document.write("</code></body></html>");
    //    codeWnd.document.close();
    //}
    DXDemo.SetCurrentAdaptiveTheme = function(theme) {
        ASPxClientUtils.SetCookie(DXDemo.CurrentAdaptiveThemeCookieKey, theme);
        forceReloadPage();
    };
    DXDemo.SetCurrentTheme = function(theme) {
        var cookieKey = DXDemo.CurrentThemeAspCookieKey;
        if(ShowAllThemesButton.cpUseDevExtremeCookieKey)
            cookieKey = DXDemo.CurrentDevExtremeThemeCookieKey;
        ASPxClientUtils.SetCookie(cookieKey, theme);
        forceReloadPage();
    };
    DXDemo.OnShowAllThemesClick = function() {
        var themesListsNames = ShowAllThemesButton.cpThemesListsNames;
        for(var i = 0; i < themesListsNames.length; i++) {
            var themesList = window[themesListsNames[i]];
            themesList.SetVisible(!themesList.GetVisible());
        }
        var showAllThemesText = 'Show All Themes';
        var showTopThemesText = 'Show Top Themes';
        ShowAllThemesButton.SetText(ShowAllThemesButton.GetText() != showAllThemesText ? showAllThemesText : showTopThemesText);
    };
    DXDemo.OnThemesListSelectedIndexChanged = function(sender) {
        var selectedThemeName = sender.GetSelectedItem().value;
        if(ShowAllThemesButton.cpCurrenTheme != selectedThemeName)
            DXDemo.SetCurrentTheme(selectedThemeName !== 'Default' ? selectedThemeName : '');
    };
    DXDemo.OnThemesListInit = function(sender) {
        var mainElement = sender.GetMainElement();
        var itemElements = Array.prototype.slice.call(mainElement.getElementsByClassName("item"), 0);
        var newItemElements = itemElements.filter(function(elem) {
            return sender.cpNewThemes.indexOf(elem.textContent.trim()) !== -1;
        });
        newItemElements.forEach(function(itemElement) {
            if(itemElement.className.indexOf("new-item") === -1)
                itemElement.className += " new-item";
        });
    };
    DXDemo.SetCurrentFont = function(font) {
        ASPxClientUtils.SetCookie(DXDemo.CurrentFontCookieKey, font);
        forceReloadPage();
    };
    DXDemo.SetCurrentAdaptiveBaseColor = function(color) {
        ASPxClientUtils.SetCookie(DXDemo.CurrentAdaptiveBaseColorCookieKey, color);
        forceReloadPage();
    };
    DXDemo.SetCurrentBaseColor = function(color) {
        ASPxClientUtils.SetCookie(DXDemo.CurrentBaseColorCookieKey, color);
        forceReloadPage();
    };
    var forceReloadPage = function() {
        if(document.forms[0] && (!document.forms[0].onsubmit
            || (document.forms[0].onsubmit.toString().indexOf("Sys.Mvc.AsyncForm") == -1 && !document.forms[0].hasAttribute("data-ajax")))) {
            // for export purposes
            var eventTarget = document.getElementById("__EVENTTARGET");
            if(eventTarget)
                eventTarget.value = "";
            var eventArgument = document.getElementById("__EVENTARGUMENT");
            if(eventArgument)
                eventArgument.value = "";

            document.forms[0].submit();
        } else {
            window.location.reload();
        }
    };
    //DXDemo.CodeNavBar_HeaderClick = function(s, e) {
    //    var source = ASPx.Evt.GetEventSource(e.htmlEvent);
    //    var tag = source.tagName;
    //    e.cancel = tag != "A" && tag != "IMG";
    //}
    DXDemo.ShowScreenshotWindow = function(evt, link, useExtendedPopup) {
        DXDemo.ShowScreenshot(link.href, useExtendedPopup);
        evt.cancelBubble = true;
        return false;
    };
    DXDemo.ShowScreenshot = function(src, useExtendedPopup) {
        var getPopupFunc = useExtendedPopup ? DXDemo.getScreenshotExtendedPopup : DXDemo.getScreenshotPopup;
        DXDemo.ShowScreenshotCore(src, getPopupFunc);
    };
    DXDemo.ShowScreenshotCore = function(src, getPopupFunc) {
        var screenLeft = document.all && !document.opera ? window.screenLeft : window.screenX;
        var screenWidth = screen.availWidth;
        var screenHeight = screen.availHeight;
        var zeroX = Math.floor((screenLeft < 0 ? 0 : screenLeft) / screenWidth) * screenWidth;

        var windowWidth = 475;
        var windowHeight = 325;
        var windowX = parseInt((screenWidth - windowWidth) / 2);
        var windowY = parseInt((screenHeight - windowHeight) / 2);
        if(windowX + windowWidth > screenWidth)
            windowX = 0;
        if(windowY + windowHeight > screenHeight)
            windowY = 0;

        windowX += zeroX;

        var popupwnd = getPopupFunc(src, windowX, windowY, windowWidth, windowHeight);
        if(popupwnd != null && popupwnd.document != null && popupwnd.document.body != null) {
            popupwnd.document.body.style.margin = "0px";
        }
    };
    DXDemo.getScreenshotPopup = function(src, windowX, windowY, windowWidth, windowHeight, showScrollbars) {
        var scrollbars = showScrollbars ? "yes" : "no";
        return window.open(src, '_blank', "left=" + windowX + ",top=" + windowY + ",width=" + windowWidth + ",height=" + windowHeight + ", scrollbars=" + scrollbars + ", resizable=no", true);
    };
    DXDemo.getScreenshotExtendedPopup = function(src, windowX, windowY, windowWidth, windowHeight) {
        var popup = DXDemo.getScreenshotPopup("", windowX, windowY, windowWidth, windowHeight, true);
        var doc = popup.document,
            img = doc.createElement("img");

        img.src = src;
        img.style.width = "100%";
        img.style.height = "100%";
        doc.body.appendChild(img);
        return popup;
    };
    //DXDemo.treeViewNodeClick = function(s, e) {
    //    var node = e.node;
    //    if(node.GetNavigateUrl() == "javascript:;") {
    //        node.SetExpanded(!node.GetExpanded());
    //    }
    //}
    //DXDemo.treeViewExpandedChanging = function(s, e) {
    //    var node = e.node;
    //    if(!node.parent && s.GetNodeCount() == 1)
    //        e.cancel = true;
    //}
    DXDemo.treeViewInit = function(s) {
        window.NavControl = new navigationControl(s, NavigationBreadCrumbsButton);
        NavControl.init();
    };

    var navigationControl = function(treeView, breadCrumbsButton) {
        this.treeView = treeView;
        this.breadCrumbsButton = breadCrumbsButton;
        this.rootTree = null;
        this.subTree = null;
        this.allDemosText = 'All Demos';
        this.firstSubTreeClassName = 'products-sub-tree';
        this.breadCrumbsButtonForwardClassName = 'arrow-right';
        this.breadCrumbsButtonBackwardClassName = 'arrow-left';
        this.listItemHoveredClassName = 'hovered';
        this.isMoving = false;

        this.isRootTreeDisplayed = true;
        this.breadText = document.getElementById('breadCrumbs');

        this.init = function() {
            this.SetSelectedClassToListItems();
            this.AddHoverHandlersToListItems();
            ASPx.AddClassNameToElement(this.treeView.GetMainElement(), this.firstSubTreeClassName);
            this.GoToSelectedProductSubTree(true);
            document.getElementById("NavControl").style.visibility = '';

            this.treeView.NodeClick.AddHandler(function(s, e) {
                if(!e.node.navigateUrl || e.node.navigateUrl === ASPx.AccessibilityEmptyUrl) {
                    if(e.node.parent)
                        e.node.SetExpanded(!e.node.GetExpanded());
                    else
                        this.gotToSubTree(s, e);
                }
            }.bind(this));

        };

        this.onNavigationBreadCrumbsButtonClick = function() {
            if(this.isMoving)
                return;

            this.isMoving = true;
            if(this.isRootTreeDisplayed)
                this.GoToSelectedProductSubTree(false);
            else
                this.GoToRoot();
        };

        this.GoToSelectedProductSubTree = function(quick) {
            var selectedNodeParent = this.GetSelectedProductNode();
            if(!selectedNodeParent)
                return;

            this.gotToSubTree(
                this.treeView,
                new ASPxClientTreeViewNodeClickEventArgs(
                    false,
                    selectedNodeParent,
                    this.treeView.renderHelper.GetNodeContentElement(this.treeView.GetNodeListItem(selectedNodeParent)),
                    null
                ),
                quick
            );
        };

        this.SetSelectedClassToListItems = function() {
            var node = this.treeView.GetSelectedNode();
            while(node != null) {
                var listItemElement = this.treeView.GetNodeListItem(node);
                ASPx.AddClassNameToElement(listItemElement, 'selected');
                node = node.parent;
            }
        };

        this.AddHoverHandlersToListItems = function() {
            var nodesCount = this.treeView.GetNodeCount();
            for(var i = 0; i < nodesCount; i++) {
                var node = this.treeView.GetNode(i);
                this.AttachHoverHandlers(this.GetHoverTargetElement(node));
                for(var j = 0; j < node.nodes.length; j++) {
                    this.AttachHoverHandlers(this.GetHoverTargetElement(node.nodes[j]));
                }
            }
        };
        this.GetHoverTargetElement = function(node) {
            var listItem = this.treeView.GetNodeListItem(node);
            return listItem.querySelector('.group-node');
        };
        this.AttachHoverHandlers = function(element) {
            var parentElement = element.parentElement;
            var addHoveredClass = function() {
                if(parentElement.className.indexOf(this.listItemHoveredClassName) == -1)
                    ASPx.AddClassNameToElement(parentElement, this.listItemHoveredClassName);
            }.bind(this);
            var removeHoveredClass = function() {
                ASPx.RemoveClassNameFromElement(parentElement, this.listItemHoveredClassName);
            }.bind(this);
            element.addEventListener('mouseenter', addHoveredClass);
            element.addEventListener('mouseleave', removeHoveredClass);
        };
        this.GetSelectedProductNode = function() {
            var node = this.treeView.GetSelectedNode();
            while(node != null && node.parent != null) {
                node = node.parent;
            }
            return node;
        };

        this.gotToSubTree = function(s, e, quick) {
            this.SetBreadCrumbsText(e.node.text);
            this.breadCrumbsButton.SetText(this.allDemosText);

            this.ToggleBreadCrumbsButtonState();

            this.parent = e.htmlElement.parentNode;
            this.subTree = this.parent.getElementsByTagName('UL')[0];
            this.rootTree = this.parent.parentNode;

            var contentDiv = treeView.GetControlContentDiv();
            var mainElement = this.treeView.GetMainElement();

            mainElement.style.overflow = 'hidden';
            this.startAnimation(contentDiv, 0, -contentDiv.offsetWidth, function() {
                var contentDiv = this.treeView.GetControlContentDiv();
                contentDiv.removeChild(this.rootTree);
                contentDiv.appendChild(this.subTree);
                this.subTree.style.display = '';

                ASPx.RemoveClassNameFromElement(mainElement, this.firstSubTreeClassName);
                mainElement.style.overflow = '';

                mainElement.style.overflow = 'hidden';
                contentDiv.style.width = contentDiv.offsetWidth + 'px';
                this.startAnimation(contentDiv, contentDiv.offsetWidth, 0, function() {
                    this.isMoving = false;
                }.bind(this), quick);
                this.treeView.CorrectControlWidth();
            }.bind(this), quick);
            this.isRootTreeDisplayed = false;
        };

        this.GoToRoot = function() {
            var mainElement = this.treeView.GetMainElement();
            var contentDiv = treeView.GetControlContentDiv();
            this.breadCrumbsButton.SetText(this.GetSelectedProductNode().text);
            this.ToggleBreadCrumbsButtonState();

            this.SetBreadCrumbsText(this.allDemosText);

            mainElement.style.overflow = 'hidden';
            contentDiv.style.width = contentDiv.offsetWidth + 'px';

            this.startAnimation(contentDiv, 0, contentDiv.offsetWidth, function() {
                mainElement.style.overflow = '';
                contentDiv.removeChild(this.subTree);
                contentDiv.appendChild(this.rootTree);

                this.parent.appendChild(this.subTree);
                this.subTree.style.display = 'none';

                ASPx.AddClassNameToElement(mainElement, this.firstSubTreeClassName);
                contentDiv.style.marginLeft = -contentDiv.offsetWidth + 'px';
                this.treeView.CorrectControlWidth();

                this.startAnimation(contentDiv, -contentDiv.offsetWidth, 0, function() {
                    this.isMoving = false;
                }.bind(this));
            }.bind(this));
            this.isRootTreeDisplayed = true;
        };

        this.startAnimation = function(element, start, end, onComplete, quick) {
            if(quick)
                onComplete();
            else
                ASPx.AnimationHelper.createAnimationTransition(element, {
                    unit: 'px',
                    property: 'marginLeft',
                    duration: 200,
                    onComplete: function() { onComplete() }
                }).Start(start, end);
        };

        this.SetBreadCrumbsText = function(txt) {
            this.breadText.innerHTML = txt;
        };
        this.GetBreadCrumbsText = function() {
            return this.breadText.innerHTML;
        };
        this.ToggleBreadCrumbsButtonState = function() {
            var element = this.breadCrumbsButton.GetMainElement().getElementsByClassName("icon")[0];
            var oldCssClass = this.isRootTreeDisplayed ? this.breadCrumbsButtonForwardClassName : this.breadCrumbsButtonBackwardClassName;
            var newCssClass = this.isRootTreeDisplayed ? this.breadCrumbsButtonBackwardClassName : this.breadCrumbsButtonForwardClassName;
            ASPx.RemoveClassNameFromElement(element, oldCssClass);
            ASPx.AddClassNameToElement(element, newCssClass);
            element.className = element.className.replace(/\s{2,}/g, ' ');
        };
    }

    DXDemo.Search = {
        listenerTimeout: null,
        lastText: null,
        expandedContainerClassName: "expanded",
        SEARCH_ITEM_PREFFIX: 'sr_',
        SELECTED_SEARCH_ITEM_CLASS_NAME: 'search-result-item-selected',
        scrollableContainer: null,
        selectedItem: null,

        reInit: function() {
            DXDemo.Search.selectedItem = null;
            DXDemo.Search.scrollableContainer = null;
        },
        onSearchBoxGotFocus: function() {
            if(DXDemo.Search.listenerTimeout)
                clearTimeout(DXDemo.Search.listenerTimeout);
            DXDemo.Search.listenerTimeout = setInterval(function() {
                var text = searchEditor.GetValue();
                if(DXDemo.Search.lastText !== text) {
                    DXDemo.Search.lastText = text;
                    DXDemo.Search.doSearch(text);
                }
            }, 300);
        },
        onSearchBoxLostFocus: function() {
            if(DXDemo.Search.listenerTimeout)
                clearTimeout(DXDemo.Search.listenerTimeout);
            DXDemo.Search.listenerTimeout = null;
        },
        onItemClick: function(s, e) {
            document.location = DXDemo.Search.getNavigateUrl(e.item);
        },
        onSearchEditorKeyDown: function(s, e) {
            if(e.htmlEvent.keyCode == 27) {
                searchEditor.SetValue(null);
                return;
            }
            if(searchResults.GetMainElement().offsetHeight > 0 && DXDemo.Search.getSearchResultsContainer()) {
                if(e.htmlEvent.keyCode == 40 || !e.htmlEvent.shiftKey && e.htmlEvent.keyCode == 9) {
                    DXDemo.Search.selectItem(true);
                    DXDemo.Search.checkScrollPosition();
                    DXDemo.Search.preventEvent(e.htmlEvent);
                }
                else if(e.htmlEvent.keyCode == 38 || e.htmlEvent.shiftKey && e.htmlEvent.keyCode == 9) {
                    DXDemo.Search.selectItem(false);
                    DXDemo.Search.checkScrollPosition();
                    DXDemo.Search.preventEvent(e.htmlEvent);
                }
                else if(e.htmlEvent.keyCode == 13) {
                    if(DXDemo.Search.selectedItem != null)
                        document.location = DXDemo.Search.selectedItem.getAttribute("href");
                }
            }
        },
        getNavigateUrl: function() {
            var dataItem = navBarItem.navBar.GetItemElement(navBarItem.group.index, navBarItem.index).getElementsByClassName('demo-title')[0];
            return dataItem.getAttribute("data-navUrl");
        },
        selectItem: function(next) {
            var newIndex = -1;
            if(DXDemo.Search.selectedItem != null) {
                var selectedIndex = DXDemo.Search.getItemIndex(DXDemo.Search.selectedItem);
                newIndex = next ? selectedIndex + 1 : selectedIndex - 1;
                if(next && newIndex >= DXDemo.Search.selectedItem.parentNode.children.length)
                    newIndex = selectedIndex;
                if(!next && newIndex < 0)
                    next = 0;
            }
            else if(next) {
                newIndex = 0
            }
            ASPx.RemoveClassNameFromElement(DXDemo.Search.selectedItem, DXDemo.Search.SELECTED_SEARCH_ITEM_CLASS_NAME);
            DXDemo.Search.selectedItem = document.getElementById(DXDemo.Search.SEARCH_ITEM_PREFFIX + newIndex);
            ASPx.AddClassNameToElement(DXDemo.Search.selectedItem, DXDemo.Search.SELECTED_SEARCH_ITEM_CLASS_NAME);
        },
        getSearchResultsContainer: function() {
            return document.getElementsByClassName("search-results-container")[0];
        },
        getItemIndex: function(element) {
            var id = element.id;
            return parseInt(id.substring(DXDemo.Search.SEARCH_ITEM_PREFFIX.length, id.length));
        },
        checkScrollPosition: function() {
            var container = DXDemo.Search.getScrollableContainer();
            var selectedElement = document.querySelector('.' + DXDemo.Search.SELECTED_SEARCH_ITEM_CLASS_NAME);
            if(selectedElement == null || !DXDemo.Search.checkInView(container, selectedElement))
                DXDemo.Search.scrollToElement(container, selectedElement);
        },
        getScrollableContainer: function() {
            if(!DXDemo.Search.scrollableContainer)
                DXDemo.Search.scrollableContainer = DXDemo.Search.getScrollParent(DXDemo.Search.getSearchResultsContainer());
            return DXDemo.Search.scrollableContainer;
        },
        scrollToElement: function(container, element) {
            var scrollPositionY = element != null ? DXDemo.Search.getOffsetTopFromBody(element) - DXDemo.HeaderHeight : 0;
            if(container !== document.body)
                container.scrollTop = scrollPositionY;
            else
                window.scrollTo(document.body.scrollLeft, scrollPositionY);
        },
        checkInView: function(container, element) {
            var stickyFooterHeight = 70;
            var cTop = (container !== document.body ? container.scrollTop : window.pageYOffset) + DXDemo.HeaderHeight;
            var cBottom = cTop + (container !== document.body ? container.clientHeight : window.innerHeight);
            var eTop = DXDemo.Search.getOffsetTopFromBody(element);
            var eBottom = eTop + element.clientHeight;
            var result = (eTop >= cTop && eBottom <= cBottom - stickyFooterHeight);
            return result;
        },
        getOffsetTopFromBody: function(element) {
            var result = element.offsetTop;
            if(element.offsetParent !== null && element.offsetParent !== document.body)
                result += DXDemo.Search.getOffsetTopFromBody(element.offsetParent);
            return result;
        },
        getScrollParent: function(node) {
            if(node == null) {
                return null;
            }
            if(node === window.document.body || window.getComputedStyle(node).overflowY === 'auto') {
                return node;
            } else {
                return DXDemo.Search.getScrollParent(node.parentNode);
            }
        },
        preventEvent: function(evt) {
            if(evt.preventDefault)
                evt.preventDefault();
            else
                evt.returnValue = false;
            return false;
        },
        doSearch: function(text) {
            if(text && text.length > 2) {
                var isMvc = window.MVCxClientUtils !== undefined;
                searchResults.PerformCallback(isMvc ? { text: text } : text);
                DXDemo.Search.reInit();
            }
            else
                DXDemo.Search.setContainerVisiblity(false);
        },
        onEndCallback: function(s,e){
            DXDemo.Search.setContainerVisiblity(true);
        },
        setContainerVisiblity: function(visible) {
            var element = searchResults.GetMainElement();
            var containerElement = document.querySelector(".search-wrapper");
            if(visible) {
                slideDown(element);
                ASPx.AddClassNameToElement(containerElement, DXDemo.Search.expandedContainerClassName);
            }
            else {
                slideUp(element);
                ASPx.RemoveClassNameFromElement(containerElement, DXDemo.Search.expandedContainerClassName);
            }
        }
    }

    var slideDown = function(elem) {
        elem.style.height = getHeight(elem) + 'px';
    }
    var slideUp = function(elem) {
        elem.style.height = '0';
    }

    var getHeight = function(element) {
        var clonedElement = element.cloneNode(true);
        element.parentNode.appendChild(clonedElement);
        clonedElement.style.position = 'static';
        clonedElement.style.visibility = 'hidden';
        clonedElement.style.display = 'block';
        clonedElement.style.transition = 'none';
        clonedElement.style.height = 'auto';
        var result = clonedElement.offsetHeight;
        element.parentNode.removeChild(clonedElement);
        return result;
    }

    DXDemo.iconButtonClick = function(s, e) {
        if(e.buttonIndex === 0)
            s.Focus();
    }

    DXDemo.Intro = {
        expandedClassName: "expanded",
        onFeaturedDemoAnnotatonClick: function(s) {
            if(ASPx.ElementContainsCssClass(s, DXDemo.Intro.expandedClassName))
                ASPx.RemoveClassNameFromElement(s, DXDemo.Intro.expandedClassName);
            else
                ASPx.AddClassNameToElement(s, DXDemo.Intro.expandedClassName);
        }
    }

    var DXEventMonitor = {
        TimerId: -1,
        PendingUpdates: [ ],

        Trace: function(sender, e, eventName, encodeHtml) {
            var eventListContainer = document.getElementById("EventListContainer");
            if(eventListContainer) {
                var checkbox = document.getElementById("EventCheck" + eventName);
                if(!checkbox.checked) return;
            }
            var self = DXEventMonitor;
            var name = sender.name;
            var lastSeparator = name.lastIndexOf("_");
            if(lastSeparator > -1)
                name = name.substr(lastSeparator + 1);

            var builder = ["<table>"];
            self.BuildTraceRowHtml(builder, "Sender", name, 100);
            self.BuildTraceRowHtml(builder, "EventType", eventName.replace(/_/g, " "));
            var count = 0;
            for(var child in e) {
                if (typeof e[child] == "function") continue;
                var childValue = e[child];
                if (typeof e[child] == "object" && e[child] && e[child].name)
                    childValue = "[name: '" + e[child].name + "']";
                if (encodeHtml)
                    childValue = self.EscapeHtml(childValue);
                self.BuildTraceRowHtml(builder, count ? "" : "Arguments", child + " = " + childValue);
                count++;
            }
            builder.push("</table><br />");

            self.PendingUpdates.unshift(builder.join(""));
            if(self.TimerId < 0)
                self.TimerId = window.setTimeout(self.Update, 0);
        },

        BuildTraceRowHtml: function(builder, name, text, width) {
            builder.push("<tr><td valign=top");
            if(width)
                builder.push(" style='width: ", width, "px'");
            builder.push(">");
            if(name)
                builder.push("<b>", name, ":</b>");
            builder.push("</td><td valign=top>", text, "</td></tr>");
        },

        GetLogElement: function() {
            return document.getElementById("EventLog")
        },

        Update: function() {
            var self = DXEventMonitor;
            var element = self.GetLogElement();

            element.innerHTML = self.PendingUpdates.join("") + element.innerHTML;
            self.TimerId = -1;
            self.PendingUpdates = [ ];
        },

        Clear: function() {
           DXEventMonitor.GetLogElement().innerHTML = "";
        },

        EscapeHtml: function(str) {
            return str.replace(/&/g, '&amp;').replace(/"/g, '&quot;').replace(/'/g, '&#39;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
        }
    };

    var DXLogger = {
        executeAndLog: function(func) {
            var logger = document.getElementById("Logger");
            var logItem = func.toString();
            logItem = logItem.substr("function () { ".length);
            logItem = logItem.substr(0, logItem.length - " }".length);

            logger.value += logItem + "\r\n";
            logger.scrollTop = logger.scrollHeight;
            func.call(this);
        }
    };

    var DXUploadedFilesContainer = {
        nameCellStyle: "",
        sizeCellStyle: "",
        thumbCellStyle: "",
        useExtendedPopup: false,

        AddFile: function(fileName, fileUrl, fileSize) {
            var self = DXUploadedFilesContainer;
            var builder = ["<tr>"];

            builder.push("<td class='nameCell'");
            if(self.nameCellStyle)
                builder.push(" style='" + self.nameCellStyle + "'");
            builder.push(">");
            self.BuildLink(builder, fileName, fileUrl);
            builder.push("</td>");

            builder.push("<td class='sizeCell'");
            if(self.sizeCellStyle)
                builder.push(" style='" + self.sizeCellStyle + "'");
            builder.push(">");
            builder.push(fileSize);
            builder.push("</td>");

            builder.push("</tr>");

            var html = builder.join("");
            DXUploadedFilesContainer.AddHtml(html);
        },
        AddThumbnail: function(imgUrl, title) {
            var self = DXUploadedFilesContainer;
            var builder = ["<tr>"];
            builder.push("<td class='imgCell' style='background:url(");
            builder.push(imgUrl);
            builder.push(") no-repeat;background-size:cover;height:100px;");
            if(self.thumbCellStyle)
                builder.push(" " + self.thumbCellStyle);
            builder.push("'>");
            builder.push("</td>");
            builder.push("<td class='nameCell' style='padding-left:8px;");
            if(self.nameCellStyle)
                builder.push(" " + self.nameCellStyle);
            builder.push("'>");
            self.BuildLink(builder, title, imgUrl);
            builder.push("</td>");
            builder.push("</tr>");
            var html = builder.join("");
            DXUploadedFilesContainer.AddHtml(html);
        },
        Clear: function() {
            DXUploadedFilesContainer.ReplaceHtml("");
        },
        BuildLink: function(builder, text, url) {
            builder.push("<a target='blank' onclick='return DXDemo.ShowScreenshotWindow(event, this, " + this.useExtendedPopup + ");'");
            builder.push(" href='" + url + "'>");
            builder.push(text);
            builder.push("</a>");
        },
        AddHtml: function(html) {
            var fileContainer = document.getElementById("uploadedFilesContainer"),
                fullHtml = html;
            if(fileContainer) {
                var containerBody = fileContainer.tBodies[0];
                fullHtml = containerBody.innerHTML + html;
            }
            DXUploadedFilesContainer.ReplaceHtml(fullHtml);
        },
        ReplaceHtml: function(html) {
            var builder = ["<table id='uploadedFilesContainer' class='uploadedFilesContainer'><tbody>"];
            builder.push(html);
            builder.push("</tbody></table>");
            var contentHtml = builder.join("");
            FilesRoundPanel.SetContentHtml(contentHtml);
        },
        ApplySettings: function(nameCellStyle, sizeCellStyle, thumbCellStyle, useExtendedPopup) {
            var self = DXUploadedFilesContainer;
            self.nameCellStyle = nameCellStyle;
            self.sizeCellStyle = sizeCellStyle;
            self.thumbCellStyle = thumbCellStyle;
            self.useExtendedPopup = useExtendedPopup;
        }
    };

    var DXImagesVirtualPagingContainer = {
        TimerId: null,
        LoadedItemsCount: 0,
        LoadedItemsIndices: [],
        Trace: function(sender, evt) {
            var self = DXImagesVirtualPagingContainer;
            self.LoadedItemsIndices.push(evt.item.index);
            self.LoadedItemsCount++;
            self.EnsureLogTimeout(self, sender);
        },
        EnsureLogTimeout: function(self, sender) {
            if(self.TimerId !== null)
                clearTimeout(self.TimerId);
            self.TimerId = window.setTimeout(function () { self.Update(sender) }, 0)
        },
        InitTrace: function(sender, evt) {
            var self = DXImagesVirtualPagingContainer;
            var element = self.GetLogElement();
            var builder = ["<table>"];
            self.BuildTraceRowHtml(builder, "Total Elements Count", sender.GetItemCount(), 200);
            self.BuildTraceRowHtml(builder, "Loaded Elements Count", sender.GetLoadedItems().length, 200);
            builder.push("</table><br />");
            element.innerHTML = builder.join("");
        },
        BuildTraceRowHtml: function(builder, name, text, width) {
            builder.push("<tr><td valign=top");
            if(width)
                builder.push(" style='width: ", width, "px'");
            builder.push(">");
            if(name)
                builder.push("<b>", name, ":</b>");
            builder.push("</td><td valign=top>", text, "</td></tr>");
        },
        GetLogElement: function() {
            return document.getElementById("ImagesVirtualPagingLog")
        },
        Update: function(sender) {
            var self = DXImagesVirtualPagingContainer;
            var element = self.GetLogElement();
            var builder = ["<table>"];
            self.BuildTraceRowHtml(builder, "Total Loaded Elements Count", sender.GetLoadedItems().length, 250);
            self.BuildTraceRowHtml(builder, "Loaded Elements Count", self.LoadedItemsCount, 250);
            self.BuildTraceRowHtml(builder, "Loaded Elements Indices", self.LoadedItemsIndices.join(', '), 250);
            builder.push("</table><br />");
            element.innerHTML = builder.join("") + element.innerHTML;
            self.LoadedItemsCount = 0;
            self.LoadedItemsIndices = [];
        },
        Clear: function() {
            DXImagesVirtualPagingContainer.GetLogElement().innerHTML = "";
        }
    };

    DXDemo.HightlightedCode = {
        TOP_OFFSET_FOR_TAB_CONTROL: DXDemo.HeaderHeight,
        TOP_OFFSET_FOR_HIGHLIGHTED_BLOCK: 90,
        SCROLL_CODE_BOTTOM_PADDING: 20,
        BOTTOM_PADDING_FOR_ASPX_CODE: 100,
        BOTTOM_PADDING_FOR_CODE: 20,

        visitedTabArrayIndexes: [],

        StartScrollAnimation: function(from, to, documentScrollY) {
            var duration = to - from < 350 ? 300 : 700;

            ASPx.AnimationHelper.createSimpleAnimationTransition({
                duration: duration,
                transition: ASPx.AnimationConstants.Transitions.SINE,
                onUpdate: function(value) {
                    documentScrollY += value;
                    if(ASPx.Browser.MacOSMobilePlatform) // TODO: B157267
                        document.body.scrollTop = documentScrollY;
                    else
                        ASPx.SetDocumentScrollTop(documentScrollY);
                }
            }).Start(from, to);
        },

        GetPageControlOffsetTop: function() {
            return DemoPageControl.GetMainElement().offsetTop;
        },

        GetFileExtension: function(fileName) {
            var index = fileName.lastIndexOf('.');
            return index != -1 ? fileName.substr(index + 1) : "";
        },

        CopyPage: function(s) {
            var codeElements = Array.prototype.slice.call(document.getElementsByClassName('code'), 0);
            var codeElement = codeElements.filter(function(elem) { return elem.contains(s.GetMainElement()); })[0];
            var range = document.createRange();
            var selection = window.getSelection();
            range.selectNode(codeElement);
            selection.removeAllRanges();
            selection.addRange(range);
            document.execCommand('copy');
            selection.removeAllRanges();
        },

        InitScrollTracking: function(s) {
            var codeAreaPadding = 24;
            var codeElements = Array.prototype.slice.call(document.getElementsByClassName('code'), 0);
            var buttonElement = s.GetMainElement();
            var codeElement = codeElements.filter(function(elem) { return elem.contains(buttonElement); })[0];            

            DXDemo.HightlightedCode.AlignCopyButton(buttonElement, codeElement);
            ASPx.Evt.AttachEventToElement(window, 'scroll', function() {
                DXDemo.HightlightedCode.AlignCopyButton(buttonElement, codeElement);
            });
        },

        AlignCopyButton: function(buttonElement, codeElement) {
            var bodyTop = -document.body.getBoundingClientRect().top;
            var pageBottom = bodyTop + window.innerHeight;
            var codeElementTop = codeElement.getBoundingClientRect().top + bodyTop;
            var codeElementBottom = codeElementTop + codeElement.offsetHeight;

            var buttonTop = buttonElement.getBoundingClientRect().top;
            var buttonBottom = buttonElement.getBoundingClientRect().bottom;

            var requireMoveButton = (pageBottom > codeElementTop + 92) && (pageBottom <= codeElementBottom);
            if(requireMoveButton) {
                var diff = window.innerHeight - 24 - buttonBottom;
                var currentMarginTop = parseInt(window.getComputedStyle(buttonElement).marginTop.replace("px", ""));
                currentMarginTop += diff;
                buttonElement.style.marginTop = currentMarginTop + "px";
            }
            if(!requireMoveButton && buttonElement.style.marginTop !== "")
                buttonElement.style.marginTop = "";
        },

        DemoPageControl_OnActiveTabChanged: function(s, e) {
            if(!DXDemo.HightlightedCode.visitedTabArrayIndexes[s.GetActiveTabIndex()]) {
                if(e.tab.name != "Description") {
                    var isASPXtab = e.tab.name == "ASPX" || DXDemo.HightlightedCode.GetFileExtension(e.tab.name) == "aspx",
                        pageControlElement = DemoPageControl.GetMainElement(),
                        topElementOffset = DXDemo.HightlightedCode.GetPageControlOffsetTop(),
                        elementOffsetHeight = pageControlElement.offsetHeight,
                        topScreenOffset = DXDemo.HightlightedCode.TOP_OFFSET_FOR_TAB_CONTROL,

                        scrollDistance = 0,
                        documentScrollY = 0,
                        highlightedDivOffsetY = 0,
                        scrollTop = ASPx.Browser.MacOSMobilePlatform ? document.body.scrollTop : ASPx.GetDocumentScrollTop(); // TODO: B157267

                    if(isASPXtab) {
                        var highlightedBlocks = ASPx.GetNodesByClassName(document.documentElement, "HighlightedBlock");
                        if(highlightedBlocks.length > 0) {
                            topElementOffset = ASPx.GetAbsoluteY(highlightedBlocks[0]);
                            elementOffsetHeight = highlightedBlocks[0].offsetHeight;
                            topScreenOffset = DXDemo.HightlightedCode.TOP_OFFSET_FOR_HIGHLIGHTED_BLOCK;
                            highlightedDivOffsetY = topElementOffset;
                        }
                    }

                    if(topElementOffset - DXDemo.HightlightedCode.GetPageControlOffsetTop() + DXDemo.HightlightedCode.BOTTOM_PADDING_FOR_ASPX_CODE < window.innerHeight) {
                        topElementOffset = DXDemo.HightlightedCode.GetPageControlOffsetTop();
                        topScreenOffset = DXDemo.HightlightedCode.TOP_OFFSET_FOR_TAB_CONTROL;
                    } else if(topElementOffset < window.innerHeight) {
                        topElementOffset = elementOffsetHeight;
                        topScreenOffset = DXDemo.HightlightedCode.TOP_OFFSET_FOR_TAB_CONTROL;
                    }

                    var pageHeightBelowScreen = document.body.scrollHeight - scrollTop - window.innerHeight;
                    var endCodeContainer = pageControlElement.offsetTop + pageControlElement.offsetHeight - window.innerHeight;
                    if(elementOffsetHeight < window.innerHeight && highlightedDivOffsetY - DXDemo.HightlightedCode.GetPageControlOffsetTop() > window.innerHeight)
                        scrollDistance = highlightedDivOffsetY + elementOffsetHeight - window.innerHeight + DXDemo.HightlightedCode.SCROLL_CODE_BOTTOM_PADDING;
                    else
                        scrollDistance = topElementOffset - topScreenOffset > pageHeightBelowScreen ? endCodeContainer : topElementOffset - topScreenOffset;

                    if(scrollTop > scrollDistance)
                        scrollDistance += scrollTop;

                    var highlightedDivBottomY = highlightedDivOffsetY + elementOffsetHeight;
                    var pageControlBottomY = pageControlElement.offsetTop + pageControlElement.offsetHeight;
                    var bottomOfScreenOnPage = scrollTop + window.innerHeight + DXDemo.HightlightedCode.BOTTOM_PADDING_FOR_CODE;

                    if(isASPXtab && highlightedDivBottomY > bottomOfScreenOnPage || pageControlBottomY > bottomOfScreenOnPage)
                        DXDemo.HightlightedCode.StartScrollAnimation(scrollTop, scrollDistance, documentScrollY);
                }
                DXDemo.HightlightedCode.visitedTabArrayIndexes[s.GetActiveTabIndex()] = true;
            }
        }
    };
    function selectorPopupContainerElement_Click(popupControl, event) {
        var eventSource = ASPx.Evt.GetEventSource(event);
        if(eventSource && eventSource.className.indexOf('dxpc-content') >= 0) {
            popupControl.HideWindow();
        }
    }
    function DXSelectorPopupContainer_Init(sender) {
        var content = sender.GetWindowContentElement(-1);
        ASPxClientUtils.AttachEventToElement(content, 'click', function(event) { selectorPopupContainerElement_Click(sender, event); });
    }

    function DXThemeSettingsPopupContainer_Init(sender) {
        var content = sender.GetWindowContentElement(-1);
        var themesButtonWrapper = content.querySelector(".themes-button-wrapper");
        ASPxClientUtils.AttachEventToElement(themesButtonWrapper, 'click', function(event) { ThemeParametersPopup.Hide(); ThemeSelectorPopup.Show(); });
    }

    window.DXDemo = DXDemo;
    window.DXEventMonitor = DXEventMonitor;
    window.DXUploadedFilesContainer = DXUploadedFilesContainer;
    window.DXImagesVirtualPagingContainer = DXImagesVirtualPagingContainer;
    window.DXSelectorPopupContainer_Init = DXSelectorPopupContainer_Init;
    window.DXThemeSettingsPopupContainer_Init = DXThemeSettingsPopupContainer_Init;
    window.DXLogger = DXLogger;
})();
