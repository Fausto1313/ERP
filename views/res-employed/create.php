<?php

use yii\helpers\Html;


$this->title = 'Crear Empleado';
$this->params['breadcrumbs'][] = ['label' => 'Res Employeds', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-employed-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
