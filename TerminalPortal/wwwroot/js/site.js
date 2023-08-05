// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
    var categoryLinks = document.querySelectorAll('.dropdown-item[data-category]');

    categoryLinks.forEach(function (link) {
        link.addEventListener('click', function (event) {
            event.preventDefault();
            var category = this.getAttribute('data-category');
            filterByCategory(category);
        });
    });
});

function filterByCategory(category) {
    // Замените `YourController` и `YourAction` на соответствующий контроллер и действие для сортировки элементов
    var url = '/Home/Index?category=' + encodeURIComponent(category);
    window.location.href = url;
}