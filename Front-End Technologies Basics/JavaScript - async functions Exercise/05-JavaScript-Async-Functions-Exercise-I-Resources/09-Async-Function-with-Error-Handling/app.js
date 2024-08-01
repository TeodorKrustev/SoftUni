async function promiseRejectionAsync() {
   let promise = new Promise(function(resolve, reject){
      setTimeout(function(){
         reject("Error");
      }, 1000);
   });
   
   try{
      await promise;
   }
   catch(err){
      console.log(err);
   }
}