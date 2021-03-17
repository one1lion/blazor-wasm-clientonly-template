window.jsFuns = {
  addCssClass: function (selector, cssClass) {
    let elems = document.querySelectorAll(selector);
    if (elems) {
      for (let i = 0; i < elems.length; i++) {
        if (!elems[i].classList.contains(cssClass)) {
          elems[i].classList.add(cssClass);
        }
      }
    }
  },
  removeCssClass: function (selector, cssClass) {
    let elems = document.querySelectorAll(selector);
    if (elems) {
      for (let i = 0; i < elems.length; i++) {
        if (elems[i].classList.contains(cssClass)) {
          elems[i].classList.remove(cssClass);
        }
      }
    }
  },
  elementExists: function (elementId) {
    return document.getElementById(elementId) ? true : false;
  },
  setInputValueById: function (elementId, val) {
    return jsFuns.setInputValue(document.getElementById(elementId), val);
  },
  setInputValue: function (element, val) {
    if (element?.checked !== undefined && (val === true || val === false)) {
      element.checked = val;
      return true;
    }
    if (element?.value) {
      element.value = val;
      return true;
    }
    return false
  }
}