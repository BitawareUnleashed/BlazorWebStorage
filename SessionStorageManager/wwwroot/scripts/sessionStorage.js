/* SCRIPT FOR SESSION STORAGE*/
export function BlazorSetLocalStorage(key, value) {
    window.sessionStorage.setItem(key, value);
}

export function BlazorGetLocalStorage(key) {
    return window.sessionStorage.getItem(key);
}
/* END SCRIPT FOR SESSION STORAGE*/