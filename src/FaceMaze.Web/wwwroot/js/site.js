function defaultImage(image) {
    image.onerror = null;
    image.src = "/images/noimage.gif";
    return true;
}