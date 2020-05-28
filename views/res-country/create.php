<?php

use yii\helpers\Html;


$this->title = 'Create Res Country';
$this->params['breadcrumbs'][] = ['label' => 'Res Countries', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-country-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
