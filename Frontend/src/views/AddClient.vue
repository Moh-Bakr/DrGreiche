<template>
  <div>
    <form @submit.prevent="addClient">
      <h2 class="flexify">
        <Icon name="add-user" class="large-icon" />
        {{ this.$store.state.mode == "add" ? "إضافة عميل جديد" : "تعديل بيانات العميل" }}
      </h2>
      <section class="inputs-container">
        <div class="form-input">
          <label for="client_name">اسم العميل</label>
          <div>
            <Icon name="user" />
            <input type="text" id="client_name" name="client_name" v-model="client.english_Name" required />
          </div>
        </div>

        <div class="form-input">
          <label for="client_name_ar">الاسم بالعربية</label>
          <div>
            <Icon name="user" />
            <input type="text" id="client_name_ar" name="client_name_ar" v-model="client.arabic_Name" required />
          </div>
        </div>

        <div class="form-input">
          <label for="email">البريد الالكتروني</label>
          <div>
            <Icon name="envelope" />
            <input type="email" id="email" name="email" v-model="client.email" required />
          </div>
        </div>

        <div class="form-input">
          <label for="phone">الهاتف</label>
          <div>
            <Icon name="phone" />
            <input type="tel" id="phone" name="phone" v-model="client.phone" required/>
          </div>
        </div>

        <div class="form-input">
          <label for="mobile">الموبايل</label>
          <div>
            <Icon name="mobile" />
            <input type="tel" id="mobile" name="mobile" v-model="client.mobile" required />
          </div>
        </div>

        <div class="form-input">
          <label for="address">العنوان</label>
          <div>
            <Icon name="address" />
            <input type="text" id="address" name="address" v-model="client.address" required />
          </div>
        </div>

        <div class="form-input">
          <label for="code">كود جريش</label>
          <div>
            <Icon name="code" />
            <input type="number" id="code" name="code" v-model="client.code" required />
          </div>
        </div>
      </section>

      <input type="submit" value="حفظ" />
    </form>
  </div>
</template>

<script>
import axios from "axios";
import Icon from "@/components/Icon.vue";

export default {
  components: {
    Icon,
  },
  data() {
    return {
      client: {
        english_Name: "",
        arabic_Name: "",
        email: "",
        phone: "",
        mobile: "",
        address: "",
        code: "",
      },
    };
  },

  methods: {
    addClient() {
      if (this.$store.state.mode == "edit")
        axios
          .put(process.env.VUE_APP_Base_URL + "/client/" + this.client.id, this.client)
          .then((res) => {
            this.$router.push("/clients");
            return res;
          })
          .catch((err) => {
            return err;
          });
      else
        axios
          .post(process.env.VUE_APP_Base_URL + "/client/", this.client)
          .then((res) => {
            this.$router.push("/clients");
            return res;
          })
          .catch((err) => {
            return err;
          });
    },
  },

  mounted() {
    if (this.$store.state.mode == "edit") {
      this.client = this.$store.state.client;
    }
  },

  beforeDestroy() {
    this.$store.commit("setMode", "add");
  },
};
</script>

<style></style>
