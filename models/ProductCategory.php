<?php

namespace app\models;

use Yii;

class ProductCategory extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'product_category';
    }

    public function rules()
    {
        return [
            [['parent_path', 'name', 'complete_name'], 'string'],
            [['name'], 'required'],
            [['parent_id', 'create_uid', 'write_uid', 'removal_strategy_id'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial362'], 'string', 'max' => 1],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['parent_id'], 'exist', 'skipOnError' => true, 'targetClass' => ProductCategory::className(), 'targetAttribute' => ['parent_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'parent_path' => 'Parent Path',
            'name' => 'Name',
            'complete_name' => 'Complete Name',
            'parent_id' => 'Parent ID',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'removal_strategy_id' => 'Removal Strategy ID',
            'trial362' => 'Trial362',
        ];
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getParent()
    {
        return $this->hasOne(ProductCategory::className(), ['id' => 'parent_id']);
    }

    public function getProductCategories()
    {
        return $this->hasMany(ProductCategory::className(), ['parent_id' => 'id']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public static function find()
    {
        return new ProductCategoryQuery(get_called_class());
    }
}
