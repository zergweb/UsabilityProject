<template>
	<tr>
		<td scope="col">{{item.id}}</td>
		<td scope="col">{{item.user.name}}</td>
		<td scope="col">{{item.pulse}}</td>
		<td scope="col">{{item.temperature}}</td>
		<td scope="col">{{item.date}}</td>
	</tr>
</template>

<script>
    export default {
        name: 'SampleTableItem',
        props: {
            item: Object
        }
    }
</script>