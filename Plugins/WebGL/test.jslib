var Plugin = {
  $params: {
    conf: {
        apiKey: "AIzaSyAHF56yRPgzkRTKpoFp3z7f4rnTSdrXx_w",
        authDomain: "test-firebase-8572c.firebaseapp.com",
        databaseURL: "https://test-firebase-8572c.firebaseio.com",
        projectId: "test-firebase-8572c",
        storageBucket: "test-firebase-8572c.appspot.com",
        messagingSenderId: "370709220522",
        appId: "1:370709220522:web:af5bea73f620f2e382d4d3",
        measurementId: "G-1FC7438WJQ"
      },
    email: "HackU@gmail.com",
    pass: "abcdefg",
    db: ""
  },
  Firestore: function() {
      // firebaseの初期化
      firebase.initializeApp(params.conf);
      params.db = firebase.firestore();
  },
  Get: function(col, doc){
    params.db.collection(PtoS(col)).doc(PtoS(doc))
    .get().then(function (doc) {
      console.log("Get: ", doc.data());
      //SendMessage('Text', 'UpdateText', doc.data().doc);
    });
  },
  Get2: function(col, doc){
    params.db.collection(PtoS(col)).doc(PtoS(doc))
    .onSnapshot(function (doc) {
      console.log("Get2: ", doc.data());
      //SendMessage('Text', 'UpdateText', doc.data().doc);
    });
  },
  SetStr: function(col, doc, key, val){
  var add = {};
  add[PtoS(key)] = PtoS(val);
    //params.db.collection("users").doc("adder").set({
      params.db.collection(PtoS(col)).doc(PtoS(doc)).set(add)
    .catch(function(){
      console.log("send failed");
    })
    .then(function(){
      console.log("send success");
    });
  },
  SetInt: function(col, doc, key, val){
  var add = {};
  add[PtoS(key)] = val;
      params.db.collection(PtoS(col)).doc(PtoS(doc)).set(add)
    .catch(function(){
      console.log("send failed");
    })
    .then(function(){
      console.log("send success");
    });
  },
  SetArray: function(col, doc, key, arg, len){
    Module.refIntArray = new Int32Array(buffer, arg, len);
    var arr = [];
    for(var i=0; i<len; i++){
      arr.push(Module.refIntArray[i]);
    }
    
    var add = {};
    add[PtoS(key)] = arr;
    params.db.collection(PtoS(col)).doc(PtoS(doc)).set(add)
    .catch(function(){
      console.log("send failed");
    })
    .then(function(){
      console.log("send success");
    });
  },
  StrTest: function(ptr){
    console.log(PtoS(ptr));
  },
  $PtoS: function(ptr){
    return Pointer_stringify(ptr);
  },
  Check: function(){
    firebase.auth().onAuthStateChanged(function(user) { //ログイン状態確認
      if (user) {
        //ログイン時の処理
        console.log("login now");
      } else {
        //非ログイン時の処理
        console.log("not login");
      }
    });
  },
  Reg: function(){
    firebase.auth().createUserWithEmailAndPassword(params.email, params.pass)
      .then(function() {
        console.log("account created");
      })
      .catch(function() {
        console.log("account creation failed");
      });
  },
  Login: function(){
    firebase.auth().signInWithEmailAndPassword(params.email, params.pass)
      .then(function() {
        console.log("login success");
      })
      .catch(function() {
        console.log("login failed");
      });
  },
  Logout: function(){
    firebase.auth().signOut();
  }
};
autoAddDeps(Plugin, '$PtoS');
autoAddDeps(Plugin, '$params');
mergeInto(LibraryManager.library, Plugin);
