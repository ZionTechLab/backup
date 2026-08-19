// import React from "react";


// const Cart = () => {
//   const state = useSelector((state) => state);
//   const dispatch = useDispatch();

//   return (
//     <div className="cart">
//       <h2>Number of items in Cart: {state.numOfItems}</h2>
   
//       <button
//         onClick={() => {
//           console.log(state.isSuccess )
//           dispatch(setSuccess());
//           console.log(state.isSuccess )
//         }}
//         className="green"
//       >
//        set success
//       </button>
 
//       <button
//         onClick={() => {
//           console.log('btnclicked');
//           dispatch(addItem());
//         }}
//         className="green"
//       >
//         Add Item to Cart
//       </button>
//       <button
//         disabled={state.numOfItems > 0 ? false : true}
//         onClick={() => {
//           dispatch(deleteItem());
//         }}
//         className="red"   >
//         Remove Item from Cart
//       </button>
// ll
//       {state.isSuccess===true?'hari':'waradi'}

//     </div>
//   );
// };

// export default Cart;