/* SCRIPT FOR LOCAL STORAGE*/
export function BlazorSetLocalStorage(key, value) {
    window.localStorage.setItem(key, value);
}

export function BlazorGetLocalStorage(key) {
    return window.localStorage.getItem(key);
}
/* END SCRIPT FOR LOCAL STORAGE*/
