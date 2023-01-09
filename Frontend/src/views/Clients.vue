<template>
  <div>
    <section class="form-input flexify" style="width: 25%; margin: 20px auto">
      <label for="search" style="font-weight: bold"> بحث </label>
      <div>
        <Icon name="search" />
        <input type="text" v-model="searchQuery" style="padding: 5px 30px" @keyup.enter="getClients" />
      </div>
    </section>
    <table>
      <tr>
        <th>اسم العميل</th>
        <th>الاسم بالعربية</th>
        <th>البريد الالكتروني</th>
        <th>رقم الهاتف</th>
        <th>الموبايل</th>
        <th>العنوان</th>
        <th>كود جريش</th>
        <th></th>
      </tr>
      <tr v-for="client in clients" :key="client.id">
        <td>{{ client.english_Name }}</td>
        <td>{{ client.arabic_Name }}</td>
        <td>{{ client.email }}</td>
        <td>{{ client.phone }}</td>
        <td>{{ client.mobile }}</td>
        <td>{{ client.address }}</td>
        <td>{{ client.code }}</td>
        <td>
          <div>
            <button @click="editClient(client)">
              <Icon name="edit" />
              تعديل
            </button>
            <button @click="deleteClient(client.id)">
              <Icon name="trash" />
              حذف
            </button>
          </div>
        </td>
      </tr>
      <tr v-if="!clients.length">
        <td colspan="7">
          {{ !isLoading ? "لا يوجد عملاء" : "جاري تحميل البيانات" }}
        </td>
      </tr>
    </table>
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
      clients: [],
      isLoading: false,
      searchQuery: "",
    };
  },

  mounted() {
    this.getClients();
  },

  methods: {
    getClients() {
      this.isLoading = true;
      axios.get(process.env.VUE_APP_Base_URL + "/client/" + this.searchQuery).then((response) => {
        this.clients = response.data;
        this.isLoading = false;
      });
    },
    deleteClient(id) {
      axios.delete(process.env.VUE_APP_Base_URL + "/client/" + id).then(() => {
        this.clients = this.clients.filter((client) => client.id !== id);
      });
    },

    editClient(client) {
      this.$router.push("/add-client");
      this.$store.commit("setMode", "edit");
      this.$store.commit("saveClient", client);
    },
  },
};
</script>
