<template>
  <div id="app">
    <div id="nav">
      <router-link to="/samples">العينات</router-link> | <router-link to="/clients">العملاء</router-link> |
      <router-link to="/add-sample">{{ $store.state.mode == "edit" && $route.path == "/add-sample" ?   "تعديل بيانات العينة" :"اضافة عينة" }}</router-link> |
      <router-link to="/add-client">{{ $store.state.mode == "edit" && $route.path == "/add-client" ?  "تعديل بيانات العميل" : "إضافة عميل" }}</router-link>
    </div>
    <router-view />
  </div>
</template>

<style>
@import url("https://fonts.googleapis.com/css2?family=Cairo&display=swap");

* {
  font-family: "Cairo";
}

#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  direction: rtl;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}

form {
  width: 80%;
  margin: 20px auto;
  padding: 20px;
}

.inputs-container {
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-gap: 10px;
  margin-bottom: 10px;
}

select {
  background: white;
}

select,
input {
  width: 100%;
  outline: none;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  box-sizing: border-box;
}

input[type="submit"] {
  width: 25%;
  border-radius: 5px;
  background-color: #4caf50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  margin: auto;
}

input[type="submit"]:hover {
  opacity: 0.8;
}

.form-input {
  width: 100%;
  display: flex;
  align-items: center;
  box-sizing: border-box;
}

.form-input div {
  position: relative;
  width: 80%;
}

.form-input div .icon {
  position: absolute;
  top: 20px;
  right: 10px;
}

.form-input label {
  display: block;
  width: 20%;
}

.form-input input,
.form-input select {
  padding: 6px;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-sizing: border-box;
  padding-right: 30px;
}

.form-input input:focus {
  outline: none;
  border: 1px solid #4caf50;
}

/**********************/

table {
  border-collapse: collapse;
  width: 100%;
}

td,
th {
  border: 1px solid #dddddd;
  padding: 8px;
}

td button {
  margin: 0 5px;
  background-color: transparent;
  border: none;
  text-decoration: underline;
  cursor: pointer;
}

td button:first-of-type {
  color: blue;
  fill: blue;
}

td button:last-of-type {
  color: red;
  fill: red;
}

td:last-of-type div {
  display: flex;
  align-items: center;
  justify-content: center;
}

td:last-of-type {
  width: 80px;
}

button {
  display: flex;
  align-items: center;
  gap: 5px;
}

.flexify {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
}
</style>
