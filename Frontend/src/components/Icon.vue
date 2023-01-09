<template>
  <svg class="fill-current icon" :class="{ 'stroke-current': withStroke }" @click="$emit('clickFn')">
    <use :xlink:href="getImageUrl() + '#' + name"></use>
  </svg>
</template>

<script>
export default {
  props: {
    name: {
      type: String,
      required: true,
    },
    withStroke: {
      type: Boolean,
      default: false,
    },
  },
  methods: {
    getImageUrl() {
      return require("@/assets/sprite.svg");
    },
  },
};
</script>

<style scoped>
.icon {
  width: 1rem;
  height: 1rem;
  fill: currentColor;
}

.large-icon {
  width: 2rem;
  height: 2rem;
  fill: currentColor;
}
</style>
