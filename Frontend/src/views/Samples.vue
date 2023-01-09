<template>
  <div>
    <section class="form-input flexify" style="width: 25%; margin: 20px auto">
      <label for="search" style="font-weight: bold"> بحث </label>
      <div>
        <Icon name="search" />
        <input type="text" v-model="searchQuery" style="padding: 5px 30px" @keyup.enter="getSamples" />
      </div>
    </section>
    <table>
      <tr>
        <th>اسم العميل</th>
        <th>جهة الاستلام</th>
        <th>تاريخ الاستلام</th>
        <th>وصف العينة</th>
        <th>قيمة العينة</th>
        <th>عدد العينات</th>
        <th>حالة العينة</th>
        <th></th>
      </tr>
      <tr v-for="sample in samples" :key="sample.id">
        <td>{{ sample.client_name }}</td>
        <td>{{ sample.receiving_party }}</td>
        <td>{{ sample.date }}</td>
        <td>{{ sample.description }}</td>
        <td>{{ sample.price }}</td>
        <td>{{ sample.qutaity }}</td>
        <td>
          <div class="flexify">
            <Icon :name="sample.status" />
            {{ statusText[sample.status] }}
          </div>
        </td>
        <td>
          <div>
            <button @click="editSample(sample)">
              <Icon name="edit" />
              تعديل
            </button>
            <button @click="deleteSample(sample.id)">
              <Icon name="trash" />
              حذف
            </button>
          </div>
        </td>
      </tr>
      <tr v-if="!samples.length">
        <td colspan="7">
          {{ !isLoading ? "لا يوجد عينات" : "جاري تحميل البيانات" }}
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
      samples: [],
      isLoading: false,
      searchQuery: "",
      statusText: {
        pending: "انتظار التوجيه",
        waiting: "انتظار التشغيل",
        "in-progress": "جاري التصنيع",
        done: "منتهية",
      },
    };
  },
  
  mounted() {
    this.getSamples();
  },

  methods: {
    getSamples() {
      this.isLoading = true;
      axios.get(process.env.VUE_APP_Base_URL + "/sample/" + this.searchQuery).then((res) => {
        this.samples = res.data;
        this.isLoading = false;
      });
    },
    deleteSample(id) {
      axios.delete(process.env.VUE_APP_Base_URL + "/sample/" + id).then(() => {
        this.samples = this.samples.filter((sample) => sample.id !== id);
      });
    },

    editSample(sample) {
      this.$router.push("/add-sample");
      this.$store.commit("setMode", "edit");
      this.$store.commit("saveSample", sample);
    },
  },
};
</script>
