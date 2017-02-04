function setMenuActive(menu_id) {
    var menu_elt = document.getElementById(menu_id);
    if (menu_elt) {
        menu_elt.className = "active";
    }
}