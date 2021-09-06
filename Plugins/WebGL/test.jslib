mergeInto(LibraryManager.library, {
  // 関数呼び出し
  Hello: function () {
    window.alert("Hello, world!");
  },
  Firestore: function() {
      // firebaseのconfig
      var firebaseConfig = {
        apiKey: "AIzaSyAHF56yRPgzkRTKpoFp3z7f4rnTSdrXx_w",
        authDomain: "test-firebase-8572c.firebaseapp.com",
        databaseURL: "https://test-firebase-8572c.firebaseio.com",
        projectId: "test-firebase-8572c",
        storageBucket: "test-firebase-8572c.appspot.com",
        messagingSenderId: "370709220522",
        appId: "1:370709220522:web:af5bea73f620f2e382d4d3",
        measurementId: "G-1FC7438WJQ"
      }
      // firebaseの初期化
      firebase.initializeApp(firebaseConfig);
  },
  Get: function(){
    var db = firebase.firestore();
    var ref = db.collection("users").doc("testdoc");
    ref.get().then(function (doc) {
      console.log(doc.data());
    });
  },
  Get2: function(){
    var db = firebase.firestore();
    db.collection("users").doc("testdoc")
    .onSnapshot(function (doc) {
      
      console.log("Current data: ", doc.data());
      console.log("Current data.doc: ", doc.data().doc);
      //SendMessage('Text', 'UpdateText', doc.data().text);
    });
  },
  Set: function(){
    var db = firebase.firestore();
    db.collection("users").doc("adde").set({
      adder: "new"
    })
    .catch(function(){
      console.log("send failed");
    });
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
    var mailv = "HackU@gmail.com";
    var passv = "abcdefg";
    firebase.auth().createUserWithEmailAndPassword(mailv, passv)
      .then(function() {
        console.log("user created");
      })
      .catch(function() {
        console.log("creation failed");
      });
  },
  Login: function(){
    var email = "HackU@gmail.com";
    var passWord = "abcdefg";
    firebase.auth().signInWithEmailAndPassword(email, passWord)
      .then(function() {
        console.log("login");
      })
      .catch(function() {
        console.log("login failed");
      });
  },
  Logout: function(){
    firebase.auth().signOut();
  }
});

