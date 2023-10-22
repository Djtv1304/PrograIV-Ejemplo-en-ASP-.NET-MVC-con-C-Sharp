
    function viewProduct(productName, productDescription) {
        $("#viewProductName").text(productName);
    $("#viewProductDescription").text(productDescription);
    $('#viewProductModal').modal('show');
        }

    function hideProductModal() {
        $('#viewProductModal').modal('hide');
        }

