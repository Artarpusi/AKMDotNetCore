const tblProducts = "product";
const tblCart = "cart";
let editProductId = null;

getProductTable();
getCartTable();

function createProduct(name, description, price) {
  const products = getProducts();
  const newProduct = {
    productId: products.length > 0 ? products[products.length - 1].productId + 1 : 1,
    productName: name,
    productDescription: description,
    productPrice: price,
  };

  products.push(newProduct);
  updateLocalStorage(tblProducts, products);

  refreshTables();
  clearForm();
  successMessage("Created successfully!");
}

function editProduct(id) {
  const products = getProducts();
  const product = products.find(item => item.productId === id);
  if (!product) {
    return errorMessage("No Data Found");
  }

  editProductId = product.productId;
  $("#txtName").val(product.productName);
  $("#txtDescription").val(product.productDescription);
  $("#txtPrice").val(product.productPrice);
  $("#txtName").focus();
}

function updateProduct(id, name, description, price) {
  const products = getProducts();
  const product = products.find(item => item.productId === id);
  if (!product) {
    return errorMessage("No Data Found");
  }

  product.productName = name;
  product.productDescription = description;
  product.productPrice = price;
  
  updateLocalStorage(tblProducts, products);
  successMessage("Updating Successful");
  refreshTables();
  clearForm();
}

function deleteProduct(id) {
  Notiflix.Confirm.show(
    "Confirm",
    "Are you sure you want to delete?",
    "Yes",
    "No",
    function okCb() {
      Notiflix.Loading.dots();
      setTimeout(() => {
        Notiflix.Loading.remove();
        const products = getProducts().filter(item => item.productId !== id);
        updateLocalStorage(tblProducts, products);
        refreshTables();
        successMessage("Deleting Successful");
      }, 1000);
    }
  );
}

$("#btnSave").click(function () {
  const name = $("#txtName").val();
  const description = $("#txtDescription").val();
  const price = $("#txtPrice").val();

  Notiflix.Loading.dots();
  setTimeout(() => {
    Notiflix.Loading.remove();
    if (editProductId === null) {
      createProduct(name, description, price);
    } else {
      updateProduct(editProductId, name, description, price);
    }
  }, 1000);
});

function getProductTable() {
  if ($.fn.DataTable.isDataTable("#datatable")) {
    $("#datatable").DataTable().destroy();
  }

  const products = getProducts();
  let count = 0;
  const htmlRows = products.map(item => `
    <tr>
      <th>${++count}</th>
      <td>${item.productName}</td>
      <td>${item.productDescription}</td>
      <td>${item.productPrice} MMK</td>
      <td>
        <button class="btn btn-warning" onclick="editProduct(${item.productId})">Edit</button>
        <button class="btn btn-danger" onclick="deleteProduct(${item.productId})">Delete</button>
      </td>
      <td>
        <button class="btn btn-info" onclick="addToCartProduct(${item.productId})"><i class="fa-solid fa-plus"></i></button>  
      </td>
    </tr>
  `).join("");
  $("#tBody").html(htmlRows);
  new DataTable("#datatable");
}

function clearForm() {
  $("#txtName").val("");
  $("#txtDescription").val("");
  $("#txtPrice").val("");
  $("#txtName").focus();
}

function addToCartProduct(id) {
  const cart = getCart();
  const products = getProducts();

  const product = products.find(item => item.productId === id);
  if (!product) {
    return errorMessage("Product not found");
  }

  const cartItem = cart.find(item => item.cartProductId === id);
  if (cartItem) {
    cartItem.cartQuantity += 1;
  } else {
    cart.push({
      cartId: cart.length > 0 ? cart[cart.length - 1].cartId + 1 : 1,
      cartProductId: product.productId,
      cartProductName: product.productName,
      cartPrice: product.productPrice,
      cartQuantity: 1
    });
  }

  updateLocalStorage(tblCart, cart);
  getCartTable();
}

function getCartTable() {
  if ($.fn.DataTable.isDataTable("#cartDataTable")) {
    $("#cartDataTable").DataTable().destroy();
  }

  const cart = getCart();
  let count = 0;
  const htmlRows = cart.map(item => `
    <tr>
      <th>${++count}</th>
      <td>${item.cartProductName}</td>
      <td>${item.cartPrice} MMK</td>
      <td>
        <div class="d-flex">
          <button class="btn btn-warning" onclick="increaseCart(${item.cartId})"><i class="fa-solid fa-plus"></i></button>
          <div style="width:30px; height:30px;" class="text-center d-flex justify-content-center align-items-center">
            ${item.cartQuantity}
          </div>
          <button class="btn btn-danger" onclick="decreaseCart(${item.cartId})"><i class="fa-solid fa-minus"></i></button>
        </div>
      </td>
      <td>${item.cartPrice * item.cartQuantity} MMK</td>
      <td>
        <button class="btn btn-danger" onclick="deleteCart(${item.cartId})"><i class="fa-solid fa-trash"></i></button>
      </td>
    </tr>
  `).join("");
  $("#cartTable").html(htmlRows);
  new DataTable("#cartDataTable");
}

function deleteCart(id) {
  confirmMessage("Are you sure you want to delete?").then(() => {
    const cart = getCart().filter(item => item.cartId !== id);
    updateLocalStorage(tblCart, cart);
    successMessage("Deleting Successful");
    getCartTable();
  });
}

function increaseCart(id) {
  const cart = getCart();
  const cartItem = cart.find(item => item.cartId === id);
  if (cartItem) {
    cartItem.cartQuantity += 1;
    updateLocalStorage(tblCart, cart);
    getCartTable();
  }
}

function decreaseCart(id) {
  const cart = getCart();
  const cartItem = cart.find(item => item.cartId === id);
  if (cartItem) {
    if (cartItem.cartQuantity === 1) {
      deleteCart(id);
    } else {
      cartItem.cartQuantity -= 1;
      updateLocalStorage(tblCart, cart);
      getCartTable();
    }
  }
}

// Utility functions
function getProducts() {
    return JSON.parse(localStorage.getItem(tblProducts)) || [];
  }
  
  function getCart() {
    return JSON.parse(localStorage.getItem(tblCart)) || [];
  }
  
  function updateLocalStorage(key, data) {
    localStorage.setItem(key, JSON.stringify(data));
  }
  
  function refreshTables() {
    getProductTable();
    getCartTable();
  }

