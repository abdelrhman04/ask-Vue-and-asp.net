<template>
  <TheNavigation />

  <router-view/>
</template>

<script>
import TheNavigation from '@/components/TheNavigation'
export default {
  
  components: {
    TheNavigation

  },
}
</script>
