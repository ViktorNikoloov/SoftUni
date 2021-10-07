function solve() {
   let textArea = document.querySelector('textarea');
   let allProducts = [];
   let totalPrice = 0;

   document.querySelector('.shopping-cart').addEventListener('click', (ev) => {
      console.log(ev.target);

      if (ev.target.tagName == 'BUTTON' && ev.target.className == 'add-product') {
         const product = ev.target.parentNode.parentNode.querySelector('.product-title').textContent;
         const price = ev.target.parentNode.parentNode.querySelector('.product-line-price').textContent;

         allProducts.push(product);
         totalPrice += Number(price);

         textArea.textContent += `Added ${product} for ${price} to the cart.\n`
      } else {
         textArea.textContent += `You bought ${allProducts.join(', ')} for ${totalPrice.toFixed(2)}.`;
         [...document.querySelectorAll('button')].map(b => b.disabled = true);
      }
   })
}